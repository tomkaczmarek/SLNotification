using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCache2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationObjectCache",
                schema: "forband.notify",
                table: "NotificationObjectCache");

            migrationBuilder.RenameTable(
                name: "NotificationObjectCache",
                schema: "forband.notify",
                newName: "NotificationObjectCaches",
                newSchema: "forband.notify");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationObjectCaches",
                schema: "forband.notify",
                table: "NotificationObjectCaches",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationObjectCaches",
                schema: "forband.notify",
                table: "NotificationObjectCaches");

            migrationBuilder.RenameTable(
                name: "NotificationObjectCaches",
                schema: "forband.notify",
                newName: "NotificationObjectCache",
                newSchema: "forband.notify");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationObjectCache",
                schema: "forband.notify",
                table: "NotificationObjectCache",
                column: "Id");
        }
    }
}
