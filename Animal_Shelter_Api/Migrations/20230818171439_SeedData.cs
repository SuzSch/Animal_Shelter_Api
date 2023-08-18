using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Shelter_Api.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "FuturePets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cat_Breed",
                table: "FuturePets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CoatColor",
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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FuturePets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DogSize",
                table: "FuturePets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FivPositive",
                table: "FuturePets",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "FuturePets",
                columns: new[] { "FuturePetId", "Age", "Cat_Breed", "Color", "Discriminator", "FivPositive", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Siamese", "White", "Cat", false, "Coco" },
                    { 2, 3, "Ragamuffin", "Chestnut", "Cat", true, "Tuffy" },
                    { 3, 3, "Maine Coon", "Grey", "Cat", false, "Fernando" }
                });

            migrationBuilder.InsertData(
                table: "FuturePets",
                columns: new[] { "FuturePetId", "Age", "Breed", "CoatColor", "Discriminator", "DogSize", "Name" },
                values: new object[,]
                {
                    { 4, 4, "Corgi", "Sable", "Dog", 0, "Bing" },
                    { 5, 3, "Pug", "Brindle", "Dog", 0, "Mushroom" },
                    { 6, 1, "Great Pyrenees", "Red", "Dog", 2, "Felix" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "Cat_Breed",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "CoatColor",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "DogSize",
                table: "FuturePets");

            migrationBuilder.DropColumn(
                name: "FivPositive",
                table: "FuturePets");
        }
    }
}
