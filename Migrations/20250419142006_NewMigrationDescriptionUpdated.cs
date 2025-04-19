using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskNode.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationDescriptionUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Describtion",
                table: "TodoItems",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TodoItems",
                newName: "Describtion");
        }
    }
}
