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
            
           var statusList= _data.GetStausByName("ab");
            foreach (var status in statusList)
                Console.WriteLine(status.Name, status.Status, status.Path);
        }
    }
}
