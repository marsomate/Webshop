using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStore.Migrations
{
    // This partial class represents a migration for creating the 'Cars' table in the database.
    public partial class cars : Migration
    {
        // Override of the 'Up' method to define the changes to be applied when the migration is executed.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the 'Cars' table with specified columns and constraints.
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),  // Auto-incremental primary key
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    // Define the primary key constraint for the 'Cars' table.
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });
        }

        // Override of the 'Down' method to define the actions to be taken when rolling back the migration.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the 'Cars' table if the migration needs to be rolled back.
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
