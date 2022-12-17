using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooParadise.Infrastructure.Migrations
{
    public partial class ssa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bdded7e-767a-4ae2-862f-2c510dcc2245", "AQAAAAEAACcQAAAAEA/JAyKn/8E7+0RC+RQkOeh4sDS1pcN5oF2anVFw09ayDmcq6iE5l7NuUVHyQyMgqQ==", "b249a06b-edf0-47db-b5ae-d4c2f0cb7ff7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc158710-aad5-4c29-8415-66fc21bfe342", "AQAAAAEAACcQAAAAEHqJh4P7naxCEQLBN33zZ4XV1K5+pn8LSIj4I4XuQOuSwoG8gZDJzF5l4pHrNlHSww==", "0ed5b9d3-0521-4de2-b44f-7afefe00c709" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersPets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPets", x => new { x.PetId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersPets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPets_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb287cd3-a05c-4f55-bd63-37c7616cf770", "AQAAAAEAACcQAAAAEFq7vGdhHrhD+hLyv9e0XONMiKguOReEzLKSSALJomtVbxmzHPYD3TKouP0mImRadw==", "517c4c6e-f225-4e6e-8de1-c85b04a96201" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c7ed4c-9986-47de-a593-a978963020b3", "AQAAAAEAACcQAAAAEGL3sWrKshTfL3MvYbqJIBnFBFcWMqAU7qZiaTwIxToPh5h2/uLCQsxxRuvujskCLg==", "09b2dcb8-4d52-4d36-b4e7-57907b091d8d" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPets_UserId",
                table: "UsersPets",
                column: "UserId");
        }
    }
}
