using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventsCache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "notify",
                table: "NotificationEventMemberCaches");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                schema: "notify",
                table: "NotificationEventMemberCaches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "notify",
                table: "NotificationEventMemberCaches",
                columns: new[] { "EventId", "ProfileId", "SourceId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "notify",
                table: "NotificationEventMemberCaches");

            migrationBuilder.DropColumn(
                name: "SourceId",
                schema: "notify",
                table: "NotificationEventMemberCaches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationEventMemberCaches",
                schema: "notify",
                table: "NotificationEventMemberCaches",
                columns: new[] { "EventId", "ProfileId" });
        }
    }
}
