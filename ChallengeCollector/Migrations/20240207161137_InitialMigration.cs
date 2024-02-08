using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeCollector.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "challenge_response",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    result_file = table.Column<byte[]>(type: "bytea", nullable: false),
                    result_file_size = table.Column<long>(type: "bigint", nullable: false),
                    test_file = table.Column<byte[]>(type: "bytea", nullable: true),
                    test_file_size = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge_response", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "challenge_response");
        }
    }
}
