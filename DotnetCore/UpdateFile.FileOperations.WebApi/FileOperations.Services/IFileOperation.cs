using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FileOperations.Services
{
    public interface IFileOperation
    {
        bool FileExist(string filePath);
        byte[] DecodeFromBase64String(string base64String);
        Task<bool> UploadFile(string filePath, IFormFile file);
        Task<bool> UploadFileByteArray(string filePaht, byte[] byteArray);
    }
}
