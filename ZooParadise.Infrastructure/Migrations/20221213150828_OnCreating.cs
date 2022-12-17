using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooParadise.Infrastructure.Migrations
{
    public partial class OnCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
