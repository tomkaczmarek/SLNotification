using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationCore.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWatchTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "statistic",
                table: "Watches",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "statistic",
                table: "Watches");
        }
    }
}
