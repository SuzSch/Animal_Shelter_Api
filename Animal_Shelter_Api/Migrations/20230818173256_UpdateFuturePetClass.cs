using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Shelter_Api.Migrations
{
    public partial class UpdateFuturePetClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cat_Breed",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "FuturePets");

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 1,
                columns: new[] { "Breed", "CoatColor" },
                values: new object[] { "Siamese", "White" });

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 2,
                columns: new[] { "Breed", "CoatColor" },
                values: new object[] { "Ragamuffin", "Chestnut" });

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 3,
                columns: new[] { "Breed", "CoatColor" },
                values: new object[] { "Maine Coon", "Grey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cat_Breed",
                table: "FuturePets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "FuturePets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 1,
                columns: new[] { "Cat_Breed", "Color" },
                values: new object[] { "Siamese", "White" });

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 2,
                columns: new[] { "Cat_Breed", "Color" },
                values: new object[] { "Ragamuffin", "Chestnut" });

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 3,
                columns: new[] { "Cat_Breed", "Color" },
                values: new object[] { "Maine Coon", "Grey" });
        }
    }
}
