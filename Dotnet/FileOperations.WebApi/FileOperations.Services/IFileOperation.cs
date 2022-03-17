
namespace FileOperations.Services
{
    public interface IFileOperation
    {
        string UploadFileByteArray(string filePaht, string base64String);
    }
}
