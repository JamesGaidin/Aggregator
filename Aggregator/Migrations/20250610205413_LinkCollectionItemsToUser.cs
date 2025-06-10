using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class LinkCollectionItemsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_AspNetUsers_UserId1",
                table: "CollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_UserId1",
                table: "CollectionItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CollectionItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CollectionItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_AspNetUsers_UserId",
                table: "CollectionItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_AspNetUsers_UserId",
                table: "CollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CollectionItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CollectionItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId1",
                table: "CollectionItems",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_AspNetUsers_UserId1",
                table: "CollectionItems",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
