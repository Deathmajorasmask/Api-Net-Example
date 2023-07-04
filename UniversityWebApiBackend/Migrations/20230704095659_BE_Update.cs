using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityWebApiBackend.Migrations
{
    public partial class BE_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "updateBy",
                table: "Users",
                newName: "UpdateBy");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deletedAt",
                table: "Users",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "deleteBy",
                table: "Users",
                newName: "DeleteBy");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "createBy",
                table: "Users",
                newName: "CreateBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateBy",
                table: "Users",
                newName: "updateBy");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Users",
                newName: "deletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteBy",
                table: "Users",
                newName: "deleteBy");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Users",
                newName: "createBy");
        }
    }
}
