using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using PostgresSample.Models;

namespace PostgresSample.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20151025054221_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .ForeignKey("BlogId");
                });
        }
    }
}
