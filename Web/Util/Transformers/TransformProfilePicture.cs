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
        
        public static async Task StoreACommunityPicture(IFormFile file, int community)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot/img/communities/{community}-picture.jpeg";
            var iconPath = $"{Directory.GetCurrentDirectory()}/wwwroot/img/communities/{community}-icon.jpeg";

            if(File.Exists(filePath))
                File.Delete(filePath);
            
            if(File.Exists(iconPath))
                File.Delete(iconPath);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var resizedPicture = ResizePicture.Resize(memoryStream.ToArray(), 300, 300);
                var profilePicture = File.Create(filePath);
                profilePicture.Write(resizedPicture);
                profilePicture.Close();
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var resizedPicture = ResizePicture.Resize(memoryStream.ToArray(), 20, 20);
                var profilePicture = File.Create(iconPath);
                profilePicture.Write(resizedPicture);
                profilePicture.Close();
            }
        }
    }
}