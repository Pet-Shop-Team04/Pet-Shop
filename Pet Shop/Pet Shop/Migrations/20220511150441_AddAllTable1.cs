using Microsoft.EntityFrameworkCore.Migrations;

namespace Pet_Shop.Migrations
{
    public partial class AddAllTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimalCarts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalCarts", x => new { x.CartId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_AnimalCarts_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalEvents", x => new { x.AnimalId, x.EventId });
                    table.ForeignKey(
                        name: "FK_AnimalEvents_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartAnimalProducts",
                columns: table => new
                {
                    AnimalProdactId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartAnimalProducts", x => new { x.CartId, x.AnimalProdactId });
                    table.ForeignKey(
                        name: "FK_CartAnimalProducts_AnimalProdacts_AnimalProdactId",
                        column: x => x.AnimalProdactId,
                        principalTable: "AnimalProdacts",
                        principalColumn: "AnimalProdactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartAnimalProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalCarts_AnimalId",
                table: "AnimalCarts",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalEvents_EventId",
                table: "AnimalEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_CartAnimalProducts_AnimalProdactId",
                table: "CartAnimalProducts",
                column: "AnimalProdactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "AnimalCarts");

            migrationBuilder.DropTable(
                name: "AnimalEvents");

            migrationBuilder.DropTable(
                name: "CartAnimalProducts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");
        }
    }
}
