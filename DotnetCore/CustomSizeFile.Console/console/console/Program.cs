using System;
using System.IO;
using System.Text;

namespace console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateCustomSizeFile(20, "mb");
            Console.WriteLine("Hello World!");
        }

        static void CreateCustomSizeFile(int size, string type,bool random=false)
        {
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rnd = new Random();
            string filePath = @"C:\\Temp\TestFile.txt";
            int count = 0;
            StringBuilder sb = new StringBuilder();

            switch (type)
            {
                case ("Kb"):
                    {
                        count = 1024 * size;
                        break;
                    }
                case ("mb"):
                    {
                        count = 1024 * 1024 * size;
                        break;
                    }
                default:
                    {
                        count = size;
                        break;
                    }
            }

            for (int i = 0; i <= count; i++)
            {
                if (random)
                {
                    int r = rnd.Next(0,allowedChars.Length);
                    sb.Append(allowedChars[r]);
                }
                else
                    sb.Append('A');
            }
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.AppendAllText(filePath, sb.ToString());
        }
    }
}
