#nullable enable
using System.ComponentModel.DataAnnotations;
using Web.Data.ViewModels.AbstractViewModels;
using Web.Data.ViewModels.Incoming;

namespace Web.Util.Attributes
{
    public class VerifyContentType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

                var castedObject = (IPictureVM) validationContext.ObjectInstance;

                return castedObject.Picture.ContentType != "image/jpeg" ? 
                    new ValidationResult("wrong file type") : ValidationResult.Success;
        }
    }
}