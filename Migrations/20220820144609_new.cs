using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog2.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "InProjectId",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_InProjectId",
                table: "Tasks",
                column: "InProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_InProjectId",
                table: "Tasks",
                column: "InProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_InProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_InProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "InProjectId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
