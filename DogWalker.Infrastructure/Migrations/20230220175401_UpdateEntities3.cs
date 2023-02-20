using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogWalker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_DogFamily_DogFamilyId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Dog_DogId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Walkers_WalkerId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "WalkerId",
                table: "Image",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DogId",
                table: "Image",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DogFamilyId",
                table: "Image",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_DogFamily_DogFamilyId",
                table: "Image",
                column: "DogFamilyId",
                principalTable: "DogFamily",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Dog_DogId",
                table: "Image",
                column: "DogId",
                principalTable: "Dog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Walkers_WalkerId",
                table: "Image",
                column: "WalkerId",
                principalTable: "Walkers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_DogFamily_DogFamilyId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Dog_DogId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Walkers_WalkerId",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "WalkerId",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DogId",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DogFamilyId",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_DogFamily_DogFamilyId",
                table: "Image",
                column: "DogFamilyId",
                principalTable: "DogFamily",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Dog_DogId",
                table: "Image",
                column: "DogId",
                principalTable: "Dog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Walkers_WalkerId",
                table: "Image",
                column: "WalkerId",
                principalTable: "Walkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
