using System.ComponentModel.DataAnnotations;
using Web.Data.ViewModels.Incoming;

namespace Web.Util.Attributes
{
    public class VerifyContentType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var castedObject = (IncomingOnboardingRequest) validationContext.ObjectInstance;

            return castedObject.ProfilePicture.ContentType != "image/jpeg" ? 
                new ValidationResult("wrong file type") : ValidationResult.Success;
        }
    }
}