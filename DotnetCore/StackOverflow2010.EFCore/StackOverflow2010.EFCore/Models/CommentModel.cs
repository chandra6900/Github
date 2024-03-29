﻿using System;
using System.Collections.Generic;

namespace StackOverflow2010.EFCore.Models
{
    public partial class CommentModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int PostId { get; set; }
        public int? Score { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
    }
}
