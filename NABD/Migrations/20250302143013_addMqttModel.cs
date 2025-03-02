using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NABD.Migrations
{
    /// <inheritdoc />
    public partial class addMqttModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyTemperature",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "HeartRate",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "OxygenSaturation",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "VitalDataTimestamp",
                table: "Tools");

            migrationBuilder.CreateTable(
                name: "MQTTMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OxygenSaturation = table.Column<int>(type: "int", nullable: true),
                    BodyTemperature = table.Column<float>(type: "real", nullable: true),
                    HeartRate = table.Column<int>(type: "int", nullable: true),
                    VitalDataTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MQTTMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MQTTMessages_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MQTTMessages_ToolId",
                table: "MQTTMessages",
                column: "ToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MQTTMessages");

            migrationBuilder.AddColumn<float>(
                name: "BodyTemperature",
                table: "Tools",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "HeartRate",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OxygenSaturation",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "VitalDataTimestamp",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
