using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInvest_Database_NET_7._0.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_customerList",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customerList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_employeeList",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employeeList", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_transactionList",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__transactionList", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_customerList");

            migrationBuilder.DropTable(
                name: "_employeeList");

            migrationBuilder.DropTable(
                name: "_transactionList");
        }
    }
}
