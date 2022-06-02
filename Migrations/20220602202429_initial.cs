using Microsoft.EntityFrameworkCore.Migrations;

namespace Felipe_ML.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dna",
                columns: table => new
                {
                    dnaSequence = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    isHuman = table.Column<bool>(type: "bit", nullable: true),
                    isMutant = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dna__D87608AE1206FDE8", x => x.dnaSequence);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dna");
        }
    }
}
