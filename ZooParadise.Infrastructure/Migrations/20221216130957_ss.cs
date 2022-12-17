using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooParadise.Infrastructure.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e134489-f585-4ba0-a534-6b320ff40520", "AQAAAAEAACcQAAAAEDHKSPrUMz3v9buTBXwqWhJv7bG1fKiohBIClEMXa4CgWrmUBDVUrvLbZ7upDvo4hg==", "4025ada1-1e4c-4f03-97c5-24f13c8702d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9abbfae9-bc89-4f92-880e-fc45f1d46a2b", "AQAAAAEAACcQAAAAEI/kYTdjQam/7WnnxHqc3/UETFDqcmmszRaCjy7qwFtqG1EZ+x/rYxGFDxdVxnloRA==", "2f3c85a8-3f8d-4ec6-ad08-cf8dee3ec2d2" });
        }
    }
}
