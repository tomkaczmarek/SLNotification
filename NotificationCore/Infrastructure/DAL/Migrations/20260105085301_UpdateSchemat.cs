using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "notify");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "forband.notify",
                newName: "Notifications",
                newSchema: "notify");

            migrationBuilder.RenameTable(
                name: "NotificationObjectCaches",
                schema: "forband.notify",
                newName: "NotificationObjectCaches",
                newSchema: "notify");

            migrationBuilder.RenameTable(
                name: "NotificationEventMemberCaches",
                schema: "forband.notify",
                newName: "NotificationEventMemberCaches",
                newSchema: "notify");

            migrationBuilder.RenameTable(
                name: "NotificationActiveCounts",
                schema: "forband.notify",
                newName: "NotificationActiveCounts",
                newSchema: "notify");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "forband.notify");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "notify",
                newName: "Notifications",
                newSchema: "forband.notify");

            migrationBuilder.RenameTable(
                name: "NotificationObjectCaches",
                schema: "notify",
                newName: "NotificationObjectCaches",
                newSchema: "forband.notify");

            migrationBuilder.RenameTable(
                name: "NotificationEventMemberCaches",
                schema: "notify",
                newName: "NotificationEventMemberCaches",
                newSchema: "forband.notify");

            migrationBuilder.RenameTable(
                name: "NotificationActiveCounts",
                schema: "notify",
                newName: "NotificationActiveCounts",
                newSchema: "forband.notify");
        }
    }
}
