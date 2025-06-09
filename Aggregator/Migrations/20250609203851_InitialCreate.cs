using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aggregator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CreatorName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatorOrigin = table.Column<string>(type: "TEXT", nullable: false),
                    CreatorContactInfo = table.Column<string>(type: "TEXT", nullable: false),
                    EstimatedValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateAcquired = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PurchaseSource = table.Column<string>(type: "TEXT", nullable: false),
                    PurchasePrice = table.Column<string>(type: "TEXT", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    Provenance = table.Column<string>(type: "TEXT", nullable: false),
                    AuthenticationDetails = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    InsuranceAgent = table.Column<string>(type: "TEXT", nullable: false),
                    InsurancePolicy = table.Column<string>(type: "TEXT", nullable: false),
                    InsuranceContactInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Tags = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionItems");
        }
    }
}
