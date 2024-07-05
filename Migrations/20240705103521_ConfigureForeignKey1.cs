using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffInformationApp.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureForeignKey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DutyStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareExpertise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareExpertise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullNames = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HighestLevelOfEducationId = table.Column<int>(type: "int", nullable: false),
                    DutyStationId = table.Column<int>(type: "int", nullable: false),
                    AvailabilityForRemoteWork = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_DutyStations_DutyStationId",
                        column: x => x.DutyStationId,
                        principalTable: "DutyStations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staff_EducationLevels_HighestLevelOfEducationId",
                        column: x => x.HighestLevelOfEducationId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTitleAndLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LevelOfResponsibility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BriefDescriptionOfRole = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaffLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LevelOfResponsibility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffLanguage_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaffSoftwareExpertise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareExpertiseId = table.Column<int>(type: "int", nullable: false),
                    ExpertiseLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSoftwareExpertise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSoftwareExpertise_SoftwareExpertise_SoftwareExpertiseId",
                        column: x => x.SoftwareExpertiseId,
                        principalTable: "SoftwareExpertise",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffSoftwareExpertise_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StaffId",
                table: "Projects",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DutyStationId",
                table: "Staff",
                column: "DutyStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_HighestLevelOfEducationId",
                table: "Staff",
                column: "HighestLevelOfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLanguage_LanguageId",
                table: "StaffLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffLanguage_StaffId",
                table: "StaffLanguage",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSoftwareExpertise_SoftwareExpertiseId",
                table: "StaffSoftwareExpertise",
                column: "SoftwareExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSoftwareExpertise_StaffId",
                table: "StaffSoftwareExpertise",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "StaffLanguage");

            migrationBuilder.DropTable(
                name: "StaffSoftwareExpertise");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "SoftwareExpertise");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "DutyStations");

            migrationBuilder.DropTable(
                name: "EducationLevels");
        }
    }
}
