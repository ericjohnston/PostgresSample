using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using PostgresSample.Models;

namespace PostgresSample.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964");

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
                        .ForeignKey("BlogId");
                });
        }
    }
}
