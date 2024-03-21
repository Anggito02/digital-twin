using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalTwin.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SENSOR_DEVICES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OperatingVoltage = table.Column<double>(type: "double", nullable: false),
                    OperatingCurrent = table.Column<double>(type: "double", nullable: false),
                    Length = table.Column<double>(type: "double", nullable: false),
                    Width = table.Column<double>(type: "double", nullable: false),
                    Height = table.Column<double>(type: "double", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SENSOR_DEVICES", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FUELS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EngineFuel = table.Column<double>(type: "double", nullable: false),
                    CreatedAtBySensor = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SensorDeviceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUELS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FUELS_SENSOR_DEVICES_SensorDeviceId",
                        column: x => x.SensorDeviceId,
                        principalTable: "SENSOR_DEVICES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RPMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EngineRPM = table.Column<double>(type: "double", nullable: false),
                    CreatedAtBySensor = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SensorDeviceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RPMS_SENSOR_DEVICES_SensorDeviceId",
                        column: x => x.SensorDeviceId,
                        principalTable: "SENSOR_DEVICES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TEMPERATURES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EngineTemperature = table.Column<double>(type: "double", nullable: false),
                    CreatedAtBySensor = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SensorDeviceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEMPERATURES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEMPERATURES_SENSOR_DEVICES_SensorDeviceId",
                        column: x => x.SensorDeviceId,
                        principalTable: "SENSOR_DEVICES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FUELS_SensorDeviceId",
                table: "FUELS",
                column: "SensorDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RPMS_SensorDeviceId",
                table: "RPMS",
                column: "SensorDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_TEMPERATURES_SensorDeviceId",
                table: "TEMPERATURES",
                column: "SensorDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FUELS");

            migrationBuilder.DropTable(
                name: "RPMS");

            migrationBuilder.DropTable(
                name: "TEMPERATURES");

            migrationBuilder.DropTable(
                name: "SENSOR_DEVICES");
        }
    }
}
