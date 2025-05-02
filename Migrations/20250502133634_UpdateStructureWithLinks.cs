using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserHobbyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStructureWithLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "UserHobbies");

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserHobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_UserHobbies_UserHobbyId",
                        column: x => x.UserHobbyId,
                        principalTable: "UserHobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Url", "UserHobbyId" },
                values: new object[,]
                {
                    { 1, "https://google.com", 1 },
                    { 2, "https://facebook.com", 2 },
                    { 3, "https://github.com", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserHobbyId",
                table: "Links",
                column: "UserHobbyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "UserHobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserHobbies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://google.com");

            migrationBuilder.UpdateData(
                table: "UserHobbies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://facebook.com");

            migrationBuilder.UpdateData(
                table: "UserHobbies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://github.com");
        }
    }
}
