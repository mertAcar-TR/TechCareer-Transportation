using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeeDemand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Demands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Demands_UserId",
                table: "Demands",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demands_Users_UserId",
                table: "Demands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demands_Users_UserId",
                table: "Demands");

            migrationBuilder.DropIndex(
                name: "IX_Demands_UserId",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Demands");

            migrationBuilder.CreateTable(
                name: "DemandUser",
                columns: table => new
                {
                    DemandsDemandId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandUser", x => new { x.DemandsDemandId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_DemandUser_Demands_DemandsDemandId",
                        column: x => x.DemandsDemandId,
                        principalTable: "Demands",
                        principalColumn: "DemandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DemandUser_UsersUserId",
                table: "DemandUser",
                column: "UsersUserId");
        }
    }
}
