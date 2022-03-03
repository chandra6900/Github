using System;
using System.Collections.Generic;

namespace StackOverflow2010.EFCore.Models
{
    public partial class BadgeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
