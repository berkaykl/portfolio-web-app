using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class edit_testimonial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterUserId",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_WriterUserId",
                table: "Testimonials",
                column: "WriterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_AspNetUsers_WriterUserId",
                table: "Testimonials",
                column: "WriterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_AspNetUsers_WriterUserId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_WriterUserId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "WriterUserId",
                table: "Testimonials");
        }
    }
}
