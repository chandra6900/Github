using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FileOperations.Services
{
    public interface IFileOperation
    {
        bool FileExist(string filePath);
        Task<bool> UploadFile(string filePath, IFormFile file);
        Task<bool> UploadFileByteArray(byte[] byteArray, string filePaht);
    }
}
