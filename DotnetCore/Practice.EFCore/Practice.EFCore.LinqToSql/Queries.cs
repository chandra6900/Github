using Practice.EFCore;
using Practice.EFCore.Models;
using System.Linq;

namespace Practice.EFCore.LinqToSql
{
    public class Queries
    {
        private readonly PracticeContext _PracticeContext;
        public Queries()
        {
            _PracticeContext = new PracticeContext();
        }
        public IQueryable<UserModel> GetUsers(bool isQuerySyntax = true)
        {
            if (isQuerySyntax)
            {
                //Linq Query Expression Syntax
                var query = from u in _PracticeContext.Users select u ;
                return query;
            }
            else
            {
                // Linq Method Extension Syntax or Fluent
                var query = _PracticeContext.Users.Select(u => u);
                return query;
            }
        }
    }
}
