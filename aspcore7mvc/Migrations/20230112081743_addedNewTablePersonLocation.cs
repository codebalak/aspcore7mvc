using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore7mvc.Migrations
{
    /// <inheritdoc />
    public partial class addedNewTablePersonLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    LocDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLocation", x => x.Id);
                    table.ForeignKey("FK_PersonID", x => x.PersonID,"Person");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLocation");
        }
    }
}
