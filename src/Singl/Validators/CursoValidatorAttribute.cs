using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Singl.Models.Validators
{
    //https://github.com/aspnet/Mvc/tree/eef6c3883a7e27b8387b0925f0b6a88df0a484c5/test/WebSites/ValidationWebSite
    //http://devkimchi.com/1901/validating-asp-net-mvc-models-with-fluent-validation/
    //http://damienbod.com/2015/10/21/asp-net-5-mvc-6-localization/
    public class CursoValidatorAttribute : ValidationAttribute, IClientModelValidator
    {
        static CursoValidatorAttribute()
        {
            // necessary to enable client side validation
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CursoValidatorAttribute), typeof(RegularExpressionAttributeAdapter));
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            throw new NotImplementedException();
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

        }
    }

public class CursoValidatorAttributeAdapter : AttributeAdapterBase<CursoValidatorAttribute>
    {
        public CursoValidatorAttributeAdapter(CursoValidatorAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-required", GetErrorMessage(context));
        }

        /// <inheritdoc />
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            return GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }    

}