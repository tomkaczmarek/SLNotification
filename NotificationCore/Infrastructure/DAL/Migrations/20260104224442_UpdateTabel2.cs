using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "forband.notify",
                table: "NotificationEventMemberCaches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "forband.notify",
                table: "NotificationEventMemberCaches",
                columns: new[] { "EventId", "ProfileId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "forband.notify",
                table: "NotificationEventMemberCaches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "forband.notify",
                table: "NotificationEventMemberCaches",
                column: "EventId");
        }
    }
}
