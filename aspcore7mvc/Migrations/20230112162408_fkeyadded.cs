using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore7mvc.Migrations
{
    /// <inheritdoc />
    public partial class fkeyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "PersonLocation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocation_PersonID",
                table: "PersonLocation",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLocation_Person_PersonID",
                table: "PersonLocation",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLocation_Person_PersonID",
                table: "PersonLocation");

            migrationBuilder.DropIndex(
                name: "IX_PersonLocation_PersonID",
                table: "PersonLocation");

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "PersonLocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
