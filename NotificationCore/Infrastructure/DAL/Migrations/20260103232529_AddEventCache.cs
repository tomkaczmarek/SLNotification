using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEventCache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarId",
                schema: "forband.notify",
                table: "NotificationObjectCaches");

            migrationBuilder.CreateTable(
                name: "notificationEventMemberCaches",
                schema: "forband.notify",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationEventMemberCaches", x => x.EventId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notificationEventMemberCaches",
                schema: "forband.notify");

            migrationBuilder.AddColumn<Guid>(
                name: "AvatarId",
                schema: "forband.notify",
                table: "NotificationObjectCaches",
                type: "uuid",
                nullable: true);
        }
    }
}
