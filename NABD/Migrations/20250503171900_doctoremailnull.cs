using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NABD.Migrations
{
    /// <inheritdoc />
    public partial class doctoremailnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "MQTTMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "MQTTMessages");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
