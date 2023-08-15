using Microsoft.AspNetCore.Http;

namespace HeavyService.Service.Interfaces.Commons;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image);
    public Task<bool> DeleteImageAsync(string subpath);
    public Task<string> UploadAvatarAsync(IFormFile avatar);
    public Task<bool> DeleteAvatarAsync(string subpath);
}