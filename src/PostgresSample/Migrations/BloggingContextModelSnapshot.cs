using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using PostgresSample.Models;

namespace PostgresSample.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("Npgsql:ValueGeneration", "Identity");

            modelBuilder.Entity("PostgresSample.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("BlogId");
                });

            modelBuilder.Entity("PostgresSample.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");
                });

            modelBuilder.Entity("PostgresSample.Models.Post", b =>
                {
                    b.HasOne("PostgresSample.Models.Blog")
                        .WithMany()
                        .ForeignKey("BlogId")
                        .WillCascadeOnDelete(true);
                });
        }
    }
}
