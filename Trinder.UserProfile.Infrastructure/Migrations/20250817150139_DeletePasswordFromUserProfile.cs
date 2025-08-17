using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trinder.UserProfile.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeletePasswordFromUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "TrinderUserProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TrinderUserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
