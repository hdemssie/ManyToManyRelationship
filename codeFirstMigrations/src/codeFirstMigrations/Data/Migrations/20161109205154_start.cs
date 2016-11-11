using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace codeFirstMigrations.Data.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "Zebras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfStrips = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zebras", x => x.Id);
                });

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Zebras");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movies",
                nullable: true);
        }
    }
}
