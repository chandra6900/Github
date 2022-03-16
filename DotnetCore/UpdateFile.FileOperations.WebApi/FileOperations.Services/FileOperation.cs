using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations.Services
{
    public class FileOperation : IFileOperation
    {
        private readonly ILogger _logger;
        public FileOperation(ILogger<FileOperation> logger)
        {
            _logger = logger;
        }

        private byte[] DecodeFromBase64String(string base64String)
        {
            try
            {
                return Convert.FromBase64String(base64String);
            }
            catch
            {

            }
            return null;
        }

        public async Task<string> UploadFile(string filePath, IFormFile file)
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
                return "Error";
            }
            return "Ok";
        }

        public async Task<string> UploadFileByteArray(string filePath, string base64String)
        {
            if (File.Exists(filePath) == false)
            {
                byte[] byteArray = DecodeFromBase64String(base64String);
                if (byteArray != null)
                {
                    try
                    {
                        await File.WriteAllBytesAsync(filePath, byteArray);
                        return "Ok";
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error while uploading the file. {ex.Message}");
                        return "Error";
                    }                   
                }
                else
                    return "BadData";
            }
            else
                return "FileExists";
        }
    }
}
