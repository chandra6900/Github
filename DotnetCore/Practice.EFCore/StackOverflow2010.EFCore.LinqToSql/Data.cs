using Practice.EFCore;
using System.Collections.Generic;
using Practice.EFCore.Models;
using System.Linq;

namespace Practice.EFCore.LinqToSql
{
    public class Data
    {
        private readonly Queries _queries;
        public Data()
        {
            _queries = new Queries();
        }
        public IEnumerable<UserModel> GetUserByDisplayName(string DisplayName,bool isQuerySyntax=true)
        {
            if (isQuerySyntax)
            {
                //Linq Query Expression Syntax
                var query = (from u in _queries.GetUsers() where u.DisplayName.Contains(DisplayName) select u).ToList();                            
                return query;
            }
            else
            {
                // Linq Method Extension Syntax or Fluent
                var query = _queries.GetUsers().Where(u => u.DisplayName.Contains(DisplayName)).Select(u => u).ToList();
                return query;
            }
        }
    }
}
