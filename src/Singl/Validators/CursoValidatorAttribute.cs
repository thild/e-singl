using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Singl.Models.Validators
{
    //https://github.com/aspnet/Mvc/tree/eef6c3883a7e27b8387b0925f0b6a88df0a484c5/test/WebSites/ValidationWebSite
    //http://devkimchi.com/1901/validating-asp-net-mvc-models-with-fluent-validation/
    //http://damienbod.com/2015/10/21/asp-net-5-mvc-6-localization/
    public class CursoValidatorAttribute : ValidationAttribute
    {
        static CursoValidatorAttribute()
        {
            // necessary to enable client side validation
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CursoValidatorAttribute), typeof(RegularExpressionAttributeAdapter));
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"Esperado uma instância de {nameof(Curso)}");
            }

            var curso = value as Curso;
            if (curso == null)
            {
                return new ValidationResult($"Esperado uma instância de {nameof(Curso)} mas foi encontrado uma instância de {value.GetType()}");
            }

            if (curso.PerfilEgresso.Contains("bla"))
            {
                return new ValidationResult("O perfil do egresso não pode conter bla");
            }
            return null;
            //              var product = value as ProductViewModel;
            //              if (product != null)
            //              {
            //                  if (!product.Country.Equals("USA") || string.IsNullOrEmpty(product.Name))
            //                  {
            //                      return new ValidationResult("Product must be made in the USA if it is not named.");
            //                  }
            //                  else
            //                  {
            //                      return null;
            //                  }
            //              }
            //              var software = value as SoftwareViewModel;
            //              if (software != null)
            //              {
            //                  if (!software.Country.Equals("USA") || string.IsNullOrEmpty(software.Name))
            //                  {
            //                      return new ValidationResult("Product must be made in the USA if it is not named.");
            //                  }
            //                  else
            //                  {
            //                      return null;
            //                  }
            //              }
            //  
            //              return new ValidationResult("Expected either ProductViewModel or SoftwareViewModel instance but got "
            //                  + value.GetType() + " instance");
        }
    }
    public class CursoValidatorAttributeAdapter : DataAnnotationsClientModelValidator<CursoValidatorAttribute>
    {
        public CursoValidatorAttributeAdapter(CursoValidatorAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(
          ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var errorMessage = GetErrorMessage(context.ModelMetadata);
            return new[] { new ModelClientValidationModelRule(errorMessage) };
        }
    }

    public class ModelClientValidationModelRule : ModelClientValidationRule
    {
        private const string _validationType = "model";

        public ModelClientValidationModelRule(string errorMessage)
            : base(_validationType, errorMessage)
        {
        }
    }



    //      public class CustomAttributeAdapter : DataAnnotationsModelValidator<EmailAttribute>
    //      {
    //          public CustomAttributeAdapter(
    //              ModelMetadata metadata,
    //              ControllerContext context,
    //              CustomAttribute attribute) :
    //              base(metadata, context, attribute)
    //          {
    //          }
    //  
    //          public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
    //          {
    //              ModelClientValidationRule rule = new ModelClientValidationRule()
    //              {
    //                  ErrorMessage = ErrorMessage,
    //                  ValidationType = "custom"
    //              };
    //              return new ModelClientValidationRule[] { rule };
    //          }
    //      }
}