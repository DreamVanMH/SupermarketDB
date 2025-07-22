using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupermarketDB.Migrations
{
    /// <inheritdoc />
    public partial class AddImageFieldsToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "products",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "products");
        }
    }
}
