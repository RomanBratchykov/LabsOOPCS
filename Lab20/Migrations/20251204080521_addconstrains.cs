using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab20.Migrations
{
    /// <inheritdoc />
    public partial class addconstrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CH_Book_AgeRestriction_Valid",
                table: "Books",
                sql: "[AgeRestriction] IN (0, 1, 2)");

            migrationBuilder.AddCheckConstraint(
                name: "CH_Book_EditionType_Valid",
                table: "Books",
                sql: "[EditionType] IN (0, 1, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CH_Book_AgeRestriction_Valid",
                table: "Books");

            migrationBuilder.DropCheckConstraint(
                name: "CH_Book_EditionType_Valid",
                table: "Books");
        }
    }
}
