using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeThiThu_Tutor.Migrations
{
    /// <inheritdoc />
    public partial class hee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "toaNhas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaChhi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toaNhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "canHos",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienTich = table.Column<double>(type: "float", nullable: false),
                    So = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToaNhaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canHos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_canHos_toaNhas_ToaNhaId",
                        column: x => x.ToaNhaId,
                        principalTable: "toaNhas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_canHos_ToaNhaId",
                table: "canHos",
                column: "ToaNhaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "canHos");

            migrationBuilder.DropTable(
                name: "toaNhas");
        }
    }
}
