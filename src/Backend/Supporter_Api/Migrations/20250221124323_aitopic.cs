using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supporter_Api.Migrations
{
    /// <inheritdoc />
    public partial class aitopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FolderId",
                table: "aITopicEntity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "aITopicEntity");
        }
    }
}
