using NLog;
using System;
using System.IO;

namespace FileOperations.Services
{
    public class FileOperation : IFileOperation
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
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

        public string UploadFileByteArray(string filePath, string base64String)
        {
            if (File.Exists(filePath) == false)
            {
                byte[] byteArray = DecodeFromBase64String(base64String);
                if (byteArray != null)
                {
                    try
                    {
                        File.WriteAllBytes(filePath, byteArray);
                        return "Ok";
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, $"Error while uploading the file. {ex.Message}");
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
