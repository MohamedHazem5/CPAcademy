using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPAcademy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLecutreIdToEnroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls");

            migrationBuilder.AlterColumn<int>(
                name: "LearnerId",
                table: "Enrolls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrolls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Enrolls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Enrolls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_UserId",
                table: "Enrolls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_AspNetUsers_UserId",
                table: "Enrolls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_AspNetUsers_UserId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_UserId",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Enrolls");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Enrolls");

            migrationBuilder.AlterColumn<int>(
                name: "LearnerId",
                table: "Enrolls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrolls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
