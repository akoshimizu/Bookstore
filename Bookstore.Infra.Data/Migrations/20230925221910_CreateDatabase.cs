﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookstore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", maxLength: 80, precision: 18, scale: 2, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Miguel de Cervantes" },
                    { 2, "Antoine de Saint-Exupéry" },
                    { 3, "J. K. Rowling" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "O maior romance da Literatura Espanhola é um clássico satírico de alta qualidade crítica.", "Dom Quixote", 29.90m },
                    { 2, 1, " Um dos principais clássicos de fantasia do mundo.", "O Senhor dos Anéis", 49.90m },
                    { 3, 2, " Um dos maiores clássicos infantis foi escrito e ilustrado pelo autor Antoine de Saint-Exupéry quando se encontrava exilado na América do Norte durante a II Guerra Mundial.", "O Pequeno Príncipe", 19.90m },
                    { 4, 3, "Em Harry Potter e a Pedra Filosofal é apresentado Harry e todo o mundo fantástico a que ele pertence, assim como os perigos pelos quais o garoto está sujeito.", "Harry Potter e a Pedra Filosofal", 39.90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
