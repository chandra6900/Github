using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileOperations.Services
{
    public interface IFileOperation
    {
        Task<string> UploadFile(string filePath, IFormFile file);
        Task<string> UploadFileByteArray(string filePaht, string base64String);
    }
}
