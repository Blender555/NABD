using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NABD.Migrations
{
    /// <inheritdoc />
    public partial class addDatainMqtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "MQTTMessages",
        columns: new[] { "Topic", "Message", "OxygenSaturation", "BodyTemperature", "HeartRate", "VitalDataTimestamp" , "ToolId" },
        values: new object[,]
        {
            { "health/sensor1", "Patient is stable", 98, 37.0f, 72, DateTime.UtcNow , 2},
            { "health/sensor2", "Heart rate slightly high", 95, 37.5f, 90, DateTime.UtcNow , 2},
            { "health/sensor3", "Low oxygen level", 88, 36.8f, 110, DateTime.UtcNow , 2}
        }
    );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MQTTMessages");
        }
    }
}
