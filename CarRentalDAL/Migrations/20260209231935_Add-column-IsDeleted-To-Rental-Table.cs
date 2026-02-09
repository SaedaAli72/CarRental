using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddcolumnIsDeletedToRentalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rentals");
        }
    }
}
