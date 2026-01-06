using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainToCache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DomainObjectsType",
                schema: "notify",
                table: "NotificationObjectCaches",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomainObjectsType",
                schema: "notify",
                table: "NotificationObjectCaches");
        }
    }
}
