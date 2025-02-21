using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supporter_Api.Migrations
{
    /// <inheritdoc />
    public partial class azuretopicmapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "azureTopicMappingEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThreadId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_azureTopicMappingEntity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "azureTopicMappingEntity");
        }
    }
}
