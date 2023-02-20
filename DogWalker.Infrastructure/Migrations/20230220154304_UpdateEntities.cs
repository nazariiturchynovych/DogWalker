using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DogWalker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Walker_WalkerId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Walker_WalkerId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Walker_AspNetUsers_UserId",
                table: "Walker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Walker",
                table: "Walker");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "DogFamily");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Dog");

            migrationBuilder.RenameTable(
                name: "Walker",
                newName: "Walkers");

            migrationBuilder.RenameIndex(
                name: "IX_Walker_UserId",
                table: "Walkers",
                newName: "IX_Walkers_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "WalkerId",
                table: "Schedule",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Walkers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Walkers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Walkers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Walkers",
                table: "Walkers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DogFamilyId = table.Column<int>(type: "integer", nullable: false),
                    DogId = table.Column<int>(type: "integer", nullable: false),
                    WalkerId = table.Column<int>(type: "integer", nullable: false),
                    ImageBytes = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_DogFamily_DogFamilyId",
                        column: x => x.DogFamilyId,
                        principalTable: "DogFamily",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_Dog_DogId",
                        column: x => x.DogId,
                        principalTable: "Dog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_Walkers_WalkerId",
                        column: x => x.WalkerId,
                        principalTable: "Walkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_DogFamilyId",
                table: "Image",
                column: "DogFamilyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_DogId",
                table: "Image",
                column: "DogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_WalkerId",
                table: "Image",
                column: "WalkerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Walkers_WalkerId",
                table: "Job",
                column: "WalkerId",
                principalTable: "Walkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Walkers_WalkerId",
                table: "Schedule",
                column: "WalkerId",
                principalTable: "Walkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walkers_AspNetUsers_UserId",
                table: "Walkers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Walkers_WalkerId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Walkers_WalkerId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Walkers_AspNetUsers_UserId",
                table: "Walkers");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Walkers",
                table: "Walkers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Walkers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Walkers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Walkers");

            migrationBuilder.RenameTable(
                name: "Walkers",
                newName: "Walker");

            migrationBuilder.RenameIndex(
                name: "IX_Walkers_UserId",
                table: "Walker",
                newName: "IX_Walker_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "WalkerId",
                table: "Schedule",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "DogFamily",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Dog",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Walker",
                table: "Walker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Walker_WalkerId",
                table: "Job",
                column: "WalkerId",
                principalTable: "Walker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Walker_WalkerId",
                table: "Schedule",
                column: "WalkerId",
                principalTable: "Walker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walker_AspNetUsers_UserId",
                table: "Walker",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
