using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolCourse.Migrations
{
    public partial class ToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GarageDoorModels",
                columns: table => new
                {
                    GarageDoorModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelName = table.Column<string>(type: "TEXT", nullable: true),
                    WindCode = table.Column<string>(type: "TEXT", nullable: true),
                    Layout = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageDoorModels", x => x.GarageDoorModelId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionName = table.Column<string>(type: "TEXT", nullable: true),
                    Key = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "GarageDoorModelSection",
                columns: table => new
                {
                    GarageDoorModelsGarageDoorModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    SectionsSectionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageDoorModelSection", x => new { x.GarageDoorModelsGarageDoorModelId, x.SectionsSectionId });
                    table.ForeignKey(
                        name: "FK_GarageDoorModelSection_GarageDoorModels_GarageDoorModelsGarageDoorModelId",
                        column: x => x.GarageDoorModelsGarageDoorModelId,
                        principalTable: "GarageDoorModels",
                        principalColumn: "GarageDoorModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarageDoorModelSection_Sections_SectionsSectionId",
                        column: x => x.SectionsSectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GarageDoorModelSection_SectionsSectionId",
                table: "GarageDoorModelSection",
                column: "SectionsSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarageDoorModelSection");

            migrationBuilder.DropTable(
                name: "GarageDoorModels");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
