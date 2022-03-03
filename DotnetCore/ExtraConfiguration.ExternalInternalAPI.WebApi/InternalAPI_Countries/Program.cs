using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace InternalAPI_Countries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Common.Program<Startup>.Main(args);
        }

    }
}
