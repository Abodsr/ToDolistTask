using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_ToDo.Migrations
{
    public partial class newmig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "Tasks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TagName",
                table: "Tasks",
                column: "TagName");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tags_TagName",
                table: "Tasks",
                column: "TagName",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tags_TagName",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TagName",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");
        }
    }
}
