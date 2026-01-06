using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEventCache2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_notificationEventMemberCaches",
                schema: "forband.notify",
                table: "notificationEventMemberCaches");

            migrationBuilder.RenameTable(
                name: "notificationEventMemberCaches",
                schema: "forband.notify",
                newName: "NotificationEventMemberCaches",
                newSchema: "forband.notify");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "forband.notify",
                table: "NotificationEventMemberCaches",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "forband.notify",
                table: "NotificationEventMemberCaches");

            migrationBuilder.RenameTable(
                name: "NotificationEventMemberCaches",
                schema: "forband.notify",
                newName: "notificationEventMemberCaches",
                newSchema: "forband.notify");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notificationEventMemberCaches",
                schema: "forband.notify",
                table: "notificationEventMemberCaches",
                column: "EventId");
        }
    }
}
