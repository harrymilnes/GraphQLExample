using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLExample.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Representative",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representative", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolved = table.Column<bool>(type: "bit", nullable: false),
                    RepresentativeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_Representative_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalTable: "Representative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Beth Dawson" },
                    { 2, "David Smith" },
                    { 3, "Jack Dickson" },
                    { 4, "Joe Doe" },
                    { 5, "Juliet Anderson" }
                });

            migrationBuilder.InsertData(
                table: "Representative",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "Richard Davidson" },
                    { 2, "Shaun Jackson" },
                    { 3, "David James" },
                    { 4, "Peter Ricks" },
                    { 5, "Emily Doe" }
                });

            migrationBuilder.InsertData(
                table: "Case",
                columns: new[] { "Id", "ClientId", "CreatedAt", "Description", "Reference", "RepresentativeId", "Resolved" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 2, 22, 19, 34, 8, 531, DateTimeKind.Utc).AddTicks(7312), "360 No scoped by a blind raindeer", "C-01", 1, true },
                    { 2, 2, new DateTime(2021, 2, 22, 19, 34, 8, 531, DateTimeKind.Utc).AddTicks(9411), "Crashed into colleagues car", "C-02", 2, true },
                    { 3, 3, new DateTime(2021, 2, 22, 19, 34, 8, 531, DateTimeKind.Utc).AddTicks(9417), "Double drop kicked my dog on the chin", "C-03", 3, false },
                    { 4, 4, new DateTime(2021, 2, 22, 19, 34, 8, 531, DateTimeKind.Utc).AddTicks(9419), "Egged my cat and ran over my friend's sheep", "C-04", 4, false },
                    { 5, 5, new DateTime(2021, 2, 22, 19, 34, 8, 531, DateTimeKind.Utc).AddTicks(9420), "Set fire to my house whilst I slept in my car", "C-05", 5, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_ClientId",
                table: "Case",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_RepresentativeId",
                table: "Case",
                column: "RepresentativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Representative");
        }
    }
}
