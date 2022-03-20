using EFCore;
using EFCore.Models;
using System.Linq;

namespace EFCore.LinqToSql
{
    public class Queries
    {
        private readonly EFCoreDBContext _EFCoreDBContext;
        public Queries()
        {
            _EFCoreDBContext = new EFCoreDBContext();
        }
        public IQueryable<StatusModel> GetUsers(bool isQuerySyntax = true)
        {
            if (isQuerySyntax)
            {
                //Linq Query Expression Syntax
                var query = from u in _EFCoreDBContext.Users select u ;
                return query;
            }
            else
            {
                // Linq Method Extension Syntax or Fluent
                var query = _EFCoreDBContext.Users.Select(u => u);
                return query;
            }
        }
    }
}
