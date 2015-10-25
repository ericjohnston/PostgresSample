using System;
using Microsoft.Data.Entity;
using PostgresSample.Models;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace PostgresSample.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_CreateIdentitySchema")]
    partial class CreateIdentitySchema
    {
        protected override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("Npgsql:ValueGeneration", "Identity");

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("Name")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("NormalizedName")
                        .Annotation("OriginalValueIndex", 3);

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "AspNetRoles");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ClaimType")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ClaimValue")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("RoleId")
                        .Annotation("OriginalValueIndex", 3);

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "AspNetRoleClaims");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ClaimType")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ClaimValue")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("UserId")
                        .Annotation("OriginalValueIndex", 3);

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "AspNetUserClaims");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("ProviderKey")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ProviderDisplayName")
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("UserId")
                        .Annotation("OriginalValueIndex", 3);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.Annotation("Relational:TableName", "AspNetUserLogins");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<string>("RoleId")
                        .Annotation("OriginalValueIndex", 1);

                    b.HasKey("UserId", "RoleId");

                    b.Annotation("Relational:TableName", "AspNetUserRoles");
                });

            builder.Entity("PostgresSample.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .Annotation("OriginalValueIndex", 0);

                    b.Property<int>("AccessFailedCount")
                        .Annotation("OriginalValueIndex", 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .Annotation("OriginalValueIndex", 2);

                    b.Property<string>("Email")
                        .Annotation("OriginalValueIndex", 3);

                    b.Property<bool>("EmailConfirmed")
                        .Annotation("OriginalValueIndex", 4);

                    b.Property<bool>("LockoutEnabled")
                        .Annotation("OriginalValueIndex", 5);

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .Annotation("OriginalValueIndex", 6);

                    b.Property<string>("NormalizedEmail")
                        .Annotation("OriginalValueIndex", 7);

                    b.Property<string>("NormalizedUserName")
                        .Annotation("OriginalValueIndex", 8);

                    b.Property<string>("PasswordHash")
                        .Annotation("OriginalValueIndex", 9);

                    b.Property<string>("PhoneNumber")
                        .Annotation("OriginalValueIndex", 10);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .Annotation("OriginalValueIndex", 11);

                    b.Property<string>("SecurityStamp")
                        .Annotation("OriginalValueIndex", 12);

                    b.Property<bool>("TwoFactorEnabled")
                        .Annotation("OriginalValueIndex", 13);

                    b.Property<string>("UserName")
                        .Annotation("OriginalValueIndex", 14);

                    b.HasKey("Id");

                    b.Annotation("Relational:TableName", "AspNetUsers");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .ForeignKey("RoleId");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PostgresSample.Models.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PostgresSample.Models.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });

            builder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .ForeignKey("RoleId");

                    b.HasOne("PostgresSample.Models.ApplicationUser")
                        .WithMany()
                        .ForeignKey("UserId");
                });
        }
    }
}
