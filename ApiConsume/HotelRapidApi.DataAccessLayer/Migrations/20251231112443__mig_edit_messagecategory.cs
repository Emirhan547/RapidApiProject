using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRapidApi.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class _mig_edit_messagecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageCategoryId",
                table: "MessageCategories",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MessageCategories",
                newName: "MessageCategoryId");
        }
    }
}
