using System;
using System.IO;
using System.Text.Unicode;

namespace FileOperations.Common
{
    public class Utilities
    {
        public static bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }
        public static byte[] DecodeFromBase64String(string base64String)
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
    }
}
