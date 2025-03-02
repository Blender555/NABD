using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NABD.Migrations
{
    /// <inheritdoc />
    public partial class addMqttModelToTool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MQTTMessages_Tools_ToolId",
                table: "MQTTMessages");

            migrationBuilder.AddForeignKey(
                name: "FK_MQTTMessages_Tools_ToolId",
                table: "MQTTMessages",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MQTTMessages_Tools_ToolId",
                table: "MQTTMessages");

            migrationBuilder.AddForeignKey(
                name: "FK_MQTTMessages_Tools_ToolId",
                table: "MQTTMessages",
                column: "ToolId",
                principalTable: "Tools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
