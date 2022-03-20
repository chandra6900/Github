using System;
using System.Collections.Generic;

namespace EFCore.Models
{
    public partial class FileStatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Path { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }
        public string Message { get; set; }
    }
}
