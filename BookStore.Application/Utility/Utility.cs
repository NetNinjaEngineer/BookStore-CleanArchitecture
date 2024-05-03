using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Utility;
public static class Utility
{
    public static (bool, string) UploadImage(IFormFile requestedImage, string folderName)
    {
        if (requestedImage.Length > 0 && requestedImage != null)
        {
            // get folder path to store images
            var booksImagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\Images", folderName);
            var uniqueImageName = $"{Guid.NewGuid()}{requestedImage.FileName}";
            var filePath = Path.Combine(booksImagesFolderPath, uniqueImageName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            requestedImage.CopyTo(fileStream);
            return (true, uniqueImageName);
        }
        return (false, string.Empty);
    }

    public static bool DeleteOldBookImage(string imageName)
    {
        if (!string.IsNullOrEmpty(imageName))
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot\\Files\\Images\\Books", imageName);
            if (File.Exists(filePath))
                File.Delete(filePath);
            return true;
        }
        return false;
    }
}
