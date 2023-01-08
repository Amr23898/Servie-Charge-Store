using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskPionner.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_services_service_id",
                        column: x => x.service_id,
                        principalTable: "services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    serial = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    operationnumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    catid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cards_Categories_catid",
                        column: x => x.catid,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cards_catid",
                table: "cards",
                column: "catid");

            migrationBuilder.CreateIndex(
                name: "IX_cards_code",
                table: "cards",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cards_operationnumber",
                table: "cards",
                column: "operationnumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cards_serial",
                table: "cards",
                column: "serial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_service_id",
                table: "Categories",
                column: "service_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
