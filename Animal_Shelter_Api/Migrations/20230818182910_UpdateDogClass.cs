using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Shelter_Api.Migrations
{
    public partial class UpdateDogClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DogSize",
                table: "FuturePets",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 4,
                column: "DogSize",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 5,
                column: "DogSize",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 6,
                column: "DogSize",
                value: "Large");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DogSize",
                table: "FuturePets",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 4,
                column: "DogSize",
                value: 0);

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 5,
                column: "DogSize",
                value: 0);

            migrationBuilder.UpdateData(
                table: "FuturePets",
                keyColumn: "FuturePetId",
                keyValue: 6,
                column: "DogSize",
                value: 2);
        }
    }
}
