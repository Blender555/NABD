using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NABD.Migrations
{
    /// <inheritdoc />
    public partial class addDataintools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
       table: "Tools",
       columns: new[] { "QrCode", "PatientId" },
       values: new object[] { "QR123456", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Tools");
        }
    }
}
