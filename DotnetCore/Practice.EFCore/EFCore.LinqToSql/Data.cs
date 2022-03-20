﻿using EFCore;
using System.Collections.Generic;
using EFCore.Models;
using System.Linq;

namespace EFCore.LinqToSql
{
    public class Data
    {
        private readonly Queries _queries;
        public Data()
        {
            _queries = new Queries();
        }
        public IEnumerable<StatusModel> GetStausByName(string Name, bool isQuerySyntax=true)
        {
            if (isQuerySyntax)
            {
                //Linq Query Expression Syntax
                var query = (from u in _queries.GetUsers() where u.Name.Contains(Name) select u).ToList();                            
                return query;
            }
            else
            {
                // Linq Method Extension Syntax or Fluent
                var query = _queries.GetUsers().Where(u => u.Name.Contains(Name)).Select(u => u).ToList();
                return query;
            }
        }
    }
}
