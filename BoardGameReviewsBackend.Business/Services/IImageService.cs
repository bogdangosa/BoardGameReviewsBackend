namespace BoardGameReviewsBackend.Business.Services;

public interface IImageService
{
    public Task<string> SaveImage(IFormFile imageFile, string[] allowedFileExtensions);
    public string DeleteImage(string fileNameWithExtension);
}