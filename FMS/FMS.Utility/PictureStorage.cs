using Microsoft.AspNetCore.Http;

namespace FMS.Utility
{
    public static class PictureStorage
    {
        public static String UploadPhoto(IFormFile model, string storageLocation)
        {
            string folderPath = storageLocation;
            folderPath += Guid.NewGuid().ToString() + "_" + model.FileName;
            return folderPath;
        }
        public static string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return ext switch
            {
                ".png" => "image/png",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
        }
    }
}
