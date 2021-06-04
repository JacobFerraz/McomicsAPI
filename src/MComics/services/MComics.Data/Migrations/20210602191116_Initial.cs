using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MComics.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagemUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemUsuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagemUsuario");
        }
    }
}
