using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StackOverflow2010.EFCore.Models;

namespace StackOverflow2010.EFCore
{
    public partial class StackOverflow2010Context : DbContext
    {
        public StackOverflow2010Context()
        {
        }

        public StackOverflow2010Context(DbContextOptions<StackOverflow2010Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BadgeModel> Badges { get; set; }
        public virtual DbSet<CommentModel> Comments { get; set; }
        public virtual DbSet<LinkTypeModel> LinkTypes { get; set; }
        public virtual DbSet<PostLinkModel> PostLinks { get; set; }
        public virtual DbSet<PostTypeModel> PostTypes { get; set; }
        public virtual DbSet<PostModel> Posts { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<VoteTypeModel> VoteTypes { get; set; }
        public virtual DbSet<VoteModel> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StackOverflow2010;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
