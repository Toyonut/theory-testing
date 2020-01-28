using Microsoft.EntityFrameworkCore.Migrations;

namespace db_app.Migrations
{
    public partial class string_field_constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StoredStrings_stringToStore",
                table: "StoredStrings",
                column: "stringToStore",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoredStrings_stringToStore",
                table: "StoredStrings");
        }
    }
}
