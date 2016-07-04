using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Singl.Models;

//https://github.com/damienbod/AspNet5IdentityServerAngularImplicitFlow/tree/secureDownloadWithAccessTokenInURL/src/IdentityServerAspNet5
//http://stackoverflow.com/questions/34502398/how-do-you-set-global-custom-headers-in-angular2
//https://www.youtube.com/watch?v=Ky7xRuY-xKQ
//http://blog.novanet.no/hooking-up-asp-net-core-1-rc1-web-api-with-auth0-bearer-tokens/
//https://www.youtube.com/watch?v=27GU9IEAYns&list=PLPCoRccv3E8UuctPlTYMWZ-Xr3g1cQj25&index=4
//http://ntakashi.net/aspnet-core-bearer-authentication/ 
//http://weblogs.asp.net/andrebaltieri/implementando-bearer-autentication-com-webapi-e-owin

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    [Authorize]
    public class AccountController : Controller
    {

        // [AllowAnonymous]
        // public ActionResult Login()
        // {
        // }

        // public ActionResult Logout()
        // {
        // }


        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        // private readonly IEmailSender _emailSender;
        // private readonly ISmsSender _smsSender;
        private readonly DatabaseContext _applicationDbContext;

        private IDataProtector _protector;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IDataProtectionProvider provider,
            // IEmailSender emailSender,
            // ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            DatabaseContext applicationDbContext)
        {
            _protector = provider.CreateProtector("auth_token");
            _userManager = userManager;
            _signInManager = signInManager;
            // _emailSender = emailSender;
            // _smsSender = smsSender;
            _applicationDbContext = applicationDbContext;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(dynamic model)
        {
            //EnsureDatabaseCreated(_applicationDbContext);
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return Ok();
                }
                //AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return new BadRequestResult();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] dynamic model, string returnUrl = null)
        {
            //EnsureDatabaseCreated(_applicationDbContext);
            //ViewData["ReturnUrl"] = returnUrl;
            string userName = model.userName.ToString();
            string password = model.password.ToString();
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                System.Console.WriteLine(model);
                var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
                var user = await _userManager.FindByNameAsync(userName);

                //var authToken = await _userManager.GenerateUserTokenAsync(user,, "auth_token");

                System.Console.WriteLine(result.IsNotAllowed);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    //return RedirectToLocal(returnUrl);
                }
                // if (result.RequiresTwoFactor)
                // {
                //     //return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                // }
                // if (result.IsLockedOut)
                // {
                //     _logger.LogWarning(2, "User account locked out.");
                //     return View("Lockout");
                // }
                // else
                // {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Ok(result);
                // }
            }

            // If we got this far, something failed, redisplay form
            return new BadRequestResult();
        }

        // public async Task<IActionResult> LogOff()
        // {
        //     await _signInManager.SignOutAsync();
        //     _logger.LogInformation(4, "User logged out.");
        //     return Ok();
        // }


        // /// <summary>
        // /// Request a new token for a given username/password pair.
        // /// </summary>
        // /// <param name="req"></param>
        // /// <returns></returns>
        // [HttpPost]
        // public dynamic Post([FromBody] dynamic req)
        // {
        //     // Obviously, at this point you need to validate the username and password against whatever system you wish.
        //     if ((req.username == "TEST" && req.password == "TEST") || (req.username == "TEST2" && req.password == "TEST"))
        //     {
        //         DateTime? expires = DateTime.UtcNow.AddMinutes(2);
        //         var token = GetToken(req.username, expires);
        //         return new { authenticated = true, entityId = 1, token = token, tokenExpires = expires };
        //     }
        //     return new { authenticated = false };
        // }

        private const string ISSUER = "localhost";

        [HttpGet("gettoken/{userName}")]
        [AllowAnonymous]
        public string GetToken(string userName, DateTime? expires)
        {
            var handler = new JwtSecurityTokenHandler();

            // Here, you should create or look up an identity for the user which is being authenticated.
            // For now, just creating a simple generic identity.
            var authScheme = new IdentityOptions().Tokens;

            //var user = await _userManager.FindByNameAsync(userName);

            var identity = new ClaimsIdentity(new GenericIdentity(userName, "TokenAuth"), new[] { new Claim(JwtRegisteredClaimNames.Aud, ISSUER) });

            var securityToken = handler.CreateToken(
                new SecurityTokenDescriptor(
                // issuer: ISSUER,
                // // audience: tokenOptions.Audience,
                // // signingCredentials: tokenOptions.SigningCredentials,
                // subject: identity,
                // expires: expires
                )
                );
            return handler.WriteToken(securityToken);
        }


        // private string GetToken()
        // {
        //     var now = DateTime.UtcNow;

        //     // Creates new keys automatically, you'd want to store these somewhere
        //     var aes = new AesCryptoServiceProvider();

        //     var signingTokenHandler = new JwtSecurityTokenHandler();
        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Claims = new List<Claim>
        //                     {
        //                         new Claim(JwtRegisteredClaimNames.Aud, "YOURWEBSITEURL")                    
        //                     },
        //         Issuer = "YourWebSite",
        //         Expires = DateTime.Now.AddHours(1),
        //         SigningCredentials = new SigningCredentials(
        //                             new SymmetricSecurityKey(aes.Key),"sha256")
        //     };

        //     var token = signingTokenHandler.CreateToken(tokenDescriptor);
        //     return signingTokenHandler.WriteToken(token);
        // }


        public static bool VerifyToken(string token)
        {
            var validationParameters = new TokenValidationParameters()
            {
                //ValidAudience = _audience,
                ValidIssuer = ISSUER,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken = null;
            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return false;
            }
            //... manual validations return false if anything untoward is discovered
            return validatedToken != null;
            //return false;
        }
    }
}