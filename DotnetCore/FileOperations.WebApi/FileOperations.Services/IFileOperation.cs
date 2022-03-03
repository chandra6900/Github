using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FileOperations.Services
{
    public interface IFileOperation
    {
        Task<byte[]> DownloadFile(string filePath);
        Task UploadFile(string filePath, IFormFile file);
        Task<string[]> GetFiles(string folderPath);
        Task<bool> DeleteFile(string filePath);
        Task<bool> DeleteFolder(string folderPath);
    }
}
