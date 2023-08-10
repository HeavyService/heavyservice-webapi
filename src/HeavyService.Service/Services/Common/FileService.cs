﻿using HeavyService.DataAccess.Interfaces.Common;
using HeavyService.Service.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HeavyService.Service.Services.Common
{
    public class FileService : IFileRepository
    {
        private readonly string IMAGE = "images";
        private readonly string ROOTPATH;

        public FileService(IWebHostEnvironment env)
        {
            ROOTPATH = env.WebRootPath;
        }
        public async Task<bool> DeleteImageAsync(string subpath)
        {
            string path = Path.Combine(ROOTPATH, subpath);
            if (File.Exists(path))
            {
                await Task.Run(() =>
                {
                    File.Delete(path);
                });

                return true;
            }

            else return false;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            string newImageName = MediaHelpers.MakeImageName(image.FileName);
            string subpath = Path.Combine(IMAGE, newImageName);
            string path = Path.Combine(ROOTPATH, subpath);
            var stream = new FileStream(path, FileMode.Create);
            await image.CopyToAsync(stream);
            stream.Close();

            return subpath;
        }
    }
}
