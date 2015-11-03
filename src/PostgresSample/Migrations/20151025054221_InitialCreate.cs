using Microsoft.Data.Entity.Migrations;

namespace PostgresSample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                });
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    BlogId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);

                    //## This method of adding a Foreign Key doesn't seem to support cascades... yet?
                    //table.ForeignKey(
                    //    name: "FK_Post_Blog_BlogId",
                    //    column: x => x.BlogId,
                    //    principalTable: "Blog",
                    //    principalColumn: "BlogId");
                });

            // Add foreign key using AddForeignKey so that Cascade will work
            migrationBuilder.AddForeignKey("FK_Post_Blog_BlogId", "Post", "BlogId", "Blog", "public", "public", "BlogId", ReferentialAction.Cascade, ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Post");
            migrationBuilder.DropTable("Blog");
        }
    }
}
