using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeCollector.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "passphrase",
                table: "challenge_response",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "unique_handle",
                table: "challenge_response",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_challenge_response_unique_handle",
                table: "challenge_response",
                column: "unique_handle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_challenge_response_unique_handle",
                table: "challenge_response");

            migrationBuilder.DropColumn(
                name: "passphrase",
                table: "challenge_response");

            migrationBuilder.DropColumn(
                name: "unique_handle",
                table: "challenge_response");
        }
    }
}
