using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace FileOperations.Services
{
    public interface IFileOperation
    {
        Task<bool> UploadFile(string filePath, IFormFile file);
        Task<bool> UploadFileByteArray(string filePaht, byte[] byteArray);
    }
}
