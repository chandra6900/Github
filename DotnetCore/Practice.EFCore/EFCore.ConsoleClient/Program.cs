using System;
using EFCore.LinqToSql;
 
namespace EFCoreClient
{
    class Program
    {
        private readonly Data _data;

        public Program()
        {
            _data = new Data();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.invoke();
        }
        public void invoke()
        {
            
           var userList= _data.GetUserByDisplayName("ab");
            foreach (var user in userList)
                Console.WriteLine(user.DisplayName,user.Location, user.WebsiteUrl);
        }
    }
}
