using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trinder.UserProfile.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAtUtc",
                table: "TrinderUserProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrinderUserProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAtUtc",
                table: "TrinderUserProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrinderUserProfiles");
        }
    }
}
