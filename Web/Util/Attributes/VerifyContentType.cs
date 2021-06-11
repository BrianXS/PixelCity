#nullable enable
using System.ComponentModel.DataAnnotations;
using Web.Data.ViewModels.Incoming;

namespace Web.Util.Attributes
{
    public class VerifyContentType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectType.Name == "IncomingUserUpdateRequest")
            {
                var castedObject = (IncomingUserUpdateRequest) validationContext.ObjectInstance;

                return castedObject.Picture.ContentType != "image/jpeg" ? 
                    new ValidationResult("wrong file type") : ValidationResult.Success;
            }

            if (validationContext.ObjectType.Name == "IncomingOnboardingRequest")
            {
                var castedObject = (IncomingOnboardingRequest) validationContext.ObjectInstance;
                
                return castedObject.ProfilePicture.ContentType != "image/jpeg" ? 
                    new ValidationResult("wrong file type") : ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}