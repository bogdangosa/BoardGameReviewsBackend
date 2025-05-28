namespace BoardGameReviewsBackend.Business.Services;

public class ImageService(IWebHostEnvironment environment): IImageService
{
    public async Task<string> SaveImage(IFormFile imageFile, string[] allowedFileExtensions)
    {
        if (imageFile == null)
        {
            throw new ArgumentNullException(nameof(imageFile));
        }
/*
        var contentPath = environment.ContentRootPath;
        var path = Path.Combine(contentPath, "Uploads");
        
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }*/
        // Check the allowed extenstions
        var ext = Path.GetExtension(imageFile.FileName);
        /*if (!allowedFileExtensions.Contains(ext))
        {
            throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");
        }
        */
        // generate a unique filename
        var imageName = $"{Guid.NewGuid().ToString()}{ext}";
        /*var fileNameWithPath = Path.Combine(path, imageName);
        using var stream = new FileStream(fileNameWithPath, FileMode.Create);
        await imageFile.CopyToAsync(stream);*/
        return imageName;
    }

    public string DeleteImage(string fileNameWithExtension)
    {
        throw new NotImplementedException();
    }
}