using System;
using System.Net;
using System.IO;
using System.Text;

namespace WebRequestor
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest req = WebRequest.Create("http://microsoft.com");
            WebResponse resp = req.GetResponse();
            StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.ASCII);
            Console.WriteLine(reader.ReadToEnd());
            Console.ReadKey();
        }
    }
}
