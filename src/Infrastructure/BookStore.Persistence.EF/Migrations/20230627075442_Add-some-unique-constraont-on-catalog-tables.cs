using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Addsomeuniqueconstraontoncatalogtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                schema: "ctlg",
                table: "Publishers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "ctlg",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FirstName_LastName",
                schema: "ctlg",
                table: "Authors",
                columns: new[] { "FirstName", "LastName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Publishers_Name",
                schema: "ctlg",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                schema: "ctlg",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Authors_FirstName_LastName",
                schema: "ctlg",
                table: "Authors");
        }
    }
}
