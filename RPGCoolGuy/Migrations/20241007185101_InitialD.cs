using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RPGCoolGuy.Migrations
{
    /// <inheritdoc />
    public partial class InitialD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: true),
                    HP = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Attack", "Defense", "HP", "Name" },
                values: new object[,]
                {
                    { 1, 20, 20, 5, "Dave" },
                    { 2, 30, 30, 1, "Tony" },
                    { 3, 99, 99, 9999, "Peter Griffin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
