using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExempleSupportPortail.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IdIssue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IdIssue);
                    table.ForeignKey(
                        name: "FK_Issue_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "IdArea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issue_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issue_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "IdArea", "Title" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Facilities" },
                    { 3, "HR" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "IdStatus", "Title" },
                values: new object[,]
                {
                    { 1, "In progress" },
                    { 2, "On hold" },
                    { 3, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Login", "Name" },
                values: new object[] { 1, "jdoe", "John Doe" });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "IdIssue", "AreaId", "Comment", "DateClosed", "DateCreated", "Description", "StatusId", "Subject", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Did you check the power cable?", null, new DateTime(2023, 1, 20, 15, 57, 33, 135, DateTimeKind.Local).AddTicks(3828), "I can't turn it on", 2, "My computer is broken", 1 },
                    { 2, 2, null, null, new DateTime(2023, 1, 20, 15, 57, 33, 135, DateTimeKind.Local).AddTicks(4019), "I can't open it", 1, "The door is broken", 1 },
                    { 3, 3, "I approve this leave request", null, new DateTime(2023, 1, 20, 15, 57, 33, 135, DateTimeKind.Local).AddTicks(4022), "I need to leave for 2 weeks", 3, "Leave request", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issue_AreaId",
                table: "Issue",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_StatusId",
                table: "Issue",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_UserId",
                table: "Issue",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
