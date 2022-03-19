using EFCore;
using EFCore.Models;
using System.Linq;

namespace EFCore.LinqToSql
{
    public class Queries
    {
        private readonly EFCoreContext _EFCoreContext;
        public Queries()
        {
            _EFCoreContext = new EFCoreContext();
        }
        public IQueryable<UserModel> GetUsers(bool isQuerySyntax = true)
        {
            if (isQuerySyntax)
            {
                //Linq Query Expression Syntax
                var query = from u in _EFCoreContext.Users select u ;
                return query;
            }
            else
            {
                // Linq Method Extension Syntax or Fluent
                var query = _EFCoreContext.Users.Select(u => u);
                return query;
            }
        }
    }
}
