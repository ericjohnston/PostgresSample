using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresSample.Models
{
    public class BloggingContext : DbContext
    {
        private AppSettings appSettings;

        public BloggingContext(IOptions<AppSettings> Settings)
        {
            appSettings = Settings.Value;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .ForeignKey(p => p.BlogId)
                .WillCascadeOnDelete();
        }
    }
}
