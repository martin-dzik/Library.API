using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookLoan",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    LoansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoan", x => new { x.BooksId, x.LoansId });
                    table.ForeignKey(
                        name: "FK_BookLoan_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoan_Loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_LoansId",
                table: "BookLoan",
                column: "LoansId");
        }
    }
}
