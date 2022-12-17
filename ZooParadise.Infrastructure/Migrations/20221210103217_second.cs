using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooParadise.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalType_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalType",
                table: "AnimalType");

            migrationBuilder.RenameTable(
                name: "AnimalType",
                newName: "AnimalTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalTypes",
                table: "AnimalTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "964bbcd7-aa9b-4890-b1b7-0cfa6c7f94d3", "AQAAAAEAACcQAAAAEL/wubD9N/2U2gqVn98l+ByEG+3H05AEWJo24obOyjPluPsfqwy9Ov56wzDvQPzfUw==", "2efa9419-7706-4b75-bb8b-22e9d0d31199" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c657e42-d31b-42eb-8b5b-20db4dca4271", "AQAAAAEAACcQAAAAEL0tkjuG3FUoJNciLubw+uJ7G0XTn/WG2/VboUUK837F1gEAL3jKh96jVa8NfIHRJg==", "17e7be4e-1e6b-4c58-8414-d6a982888831" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AnimalTypes_AnimalTypeId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalTypes",
                table: "AnimalTypes");

            migrationBuilder.RenameTable(
                name: "AnimalTypes",
                newName: "AnimalType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalType",
                table: "AnimalType",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ccf3f38-c3da-44c2-b658-a2030620bd8e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66d6b410-13dc-432d-9dce-a6059d154177", "AQAAAAEAACcQAAAAEGL4QPHGnjAbZ0L3Ho6ZJ3l7fmGfeK6ql1uNBkkl97+AAsVXFJgE6xQTx7r55PyPGw==", "3371162a-46e4-4928-b3fc-137a44131422" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a369a910-f7a2-4729-851c-92a6f8d3682d", "AQAAAAEAACcQAAAAELfQ1ljg+mZoLjZwM930+nygDV73kZzLhOyBCI/Wr4iswb2Voo8lZWkXkrsY0lKcxg==", "838a961e-58da-4a34-aa85-f9f108f9e410" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AnimalType_AnimalTypeId",
                table: "Pets",
                column: "AnimalTypeId",
                principalTable: "AnimalType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
