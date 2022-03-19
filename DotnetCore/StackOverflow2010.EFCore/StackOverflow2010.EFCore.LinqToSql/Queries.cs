using StackOverflow2010.EFCore;
using StackOverflow2010.EFCore.Models;
using System.Linq;

namespace StackOverflow2010.EFCore.LinqToSql
{
    public class Queries
    {
        private readonly StackOverflow2010Context _stackOverflow2010Context;
        public Queries()
        {
            _stackOverflow2010Context = new StackOverflow2010Context();
        }
        public IQueryable<UserModel> GetUsers(bool isQuerySyntax = true)
        {
            if (isQuerySyntax)
            {
                //Linq Query Expression Syntax
                var query = from u in _stackOverflow2010Context.Users select u ;
                return query;
            }
            else
            {
                // Linq Method Extension Syntax or Fluent
                var query = _stackOverflow2010Context.Users.Select(u => u);
                return query;
            }
        }
    }
}
