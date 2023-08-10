using Microsoft.AspNetCore.Http;

namespace HeavyService.DataAccess.Interfaces.Common;

public interface IFileRepository
{
    public Task<string> UploadImageAsync(IFormFile image);
    public Task<bool> DeleteImageAsync(string subpath);
}
