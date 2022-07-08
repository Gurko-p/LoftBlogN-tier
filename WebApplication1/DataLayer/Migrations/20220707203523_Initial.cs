using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Directories_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "Html", "Title" },
                values: new object[] { 1, "<b>First Directory's content</b>", "First Directory" });

            migrationBuilder.InsertData(
                table: "Directories",
                columns: new[] { "Id", "Html", "Title" },
                values: new object[] { 2, "<i>Second Directory's content</i>", "Second Directory" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "DirectoryId", "Html", "Title" },
                values: new object[] { 1, 1, "<b>First Material's content</b>", "First Material" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "DirectoryId", "Html", "Title" },
                values: new object[] { 2, 2, "<b>Second Material's content</b>", "Second Material" });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_DirectoryId",
                table: "Materials",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Directories");
        }
    }
}
