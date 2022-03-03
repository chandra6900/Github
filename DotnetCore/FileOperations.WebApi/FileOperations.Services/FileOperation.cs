using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading. Tasks;

namespace FileOperations.Services
{
    public class FileOperation : IFileOperation
    {
        private readonly ILogger _logger;
        public FileOperation(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<byte[]> DownloadFile(string filePath)
        {
            try {
                if (File.Exists(filePath))
                {
                    var bytes = await File.ReadAllBytesAsync(filePath);
                    return bytes;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while downloading the file, {ex.Message}");
                return null;
            }
        }

        public async Task UploadFile(string filePath, IFormFile file)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while uploading the file, {ex.Message}");
            }
        }

        public async Task<string[]> GetFiles(string folderPath)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(folderPath);
                return filePaths;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting the files info, { ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                   File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting the file, {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting the folder, {ex.Message}");
                return false;
            }
        }
    }
}
