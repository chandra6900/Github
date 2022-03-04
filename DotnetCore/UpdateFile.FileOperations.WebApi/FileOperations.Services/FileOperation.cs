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
        public FileOperation(ILogger<FileOperation> logger)
        {
            _logger = logger;
        }

        public bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }
        public async Task<bool> UploadFile(string filePath, IFormFile file)
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
                _logger.LogError($"Error while uploading the file. {ex.Message}");
                _logger.LogDebug($"Stack Trace: {ex.StackTrace}");
                return false;
            }
            return true;
        }

        public async Task<bool> UploadFileByteArray(byte[] byteArray, string filePath)
        {
            try
            {
                await File.WriteAllBytesAsync(filePath, byteArray);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while uploading the file. {ex.Message}");
                _logger.LogDebug($"Stack Trace: {ex.StackTrace}");
                return false;
            }
            return true;
        }
    }
}
