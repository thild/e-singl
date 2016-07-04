using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IOExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class FilesController : Controller
    {
        private IHostingEnvironment _environment;

        public FilesController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var path = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            System.Console.WriteLine(path);
            if (file.Length > 0)
            {
                var fileName = Path.Combine(path, ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'));
                System.Console.WriteLine(fileName);
                using (var fs = new FileStream(fileName, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            }
            return new JsonResult(new { message = "Ok" }) { StatusCode = 200 };
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string fileName)
        {
            var path = Path.Combine(_environment.WebRootPath, "uploads");
            if (System.IO.File.Exists(fileName))
            {
                await new FileInfo(fileName).DeleteAsync();
            }
            return Ok();
        }
    }
}

namespace IOExtensions
{

    public static class FileExtensions
    {
        public static Task DeleteAsync(this FileInfo fi)
        {
            return Task.Factory.StartNew(() => fi.Delete());
        }
    }
}



// [HttpPost]
// public async Task<IActionResult> Upload(ICollection<IFormFile> files)
// {
//     var uploads = Path.Combine(_environment.WebRootPath, "uploads");
//     foreach (var file in files)
//     {
//         if (file.Length > 0)
//         {
//             var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//             await file.SaveAsAsync(Path.Combine(uploads, fileName));
//         }
//     }
//     return Ok();
// }

