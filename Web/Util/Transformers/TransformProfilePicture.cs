using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Util.Transformers
{
    public static class TransformProfilePicture
    {
        public static async Task StoreProfilePicture(IFormFile file, string username)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot/img/avatars/{username}.jpeg";
            
            if(File.Exists(filePath))
                File.Delete(filePath);
            
            var profilePicture = File.Create(filePath);
            await file.CopyToAsync(profilePicture);
        }
    }
}