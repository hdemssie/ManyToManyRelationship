using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCurd.Data.Migrations
{
    public partial class movieNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Movies",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Director",
                table: "Movies",
                nullable: false);
        }
    }
}
