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

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var resizedPicture = ResizePicture.Resize(memoryStream.ToArray(), 300, 300);
                var profilePicture = File.Create(filePath);
                profilePicture.Write(resizedPicture);
                profilePicture.Close();
            }
        }
    }
}