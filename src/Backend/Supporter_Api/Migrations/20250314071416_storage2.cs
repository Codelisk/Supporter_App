using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supporter_Api.Migrations
{
    /// <inheritdoc />
    public partial class storage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepoId",
                table: "storageQuestionEntity",
                newName: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "storageQuestionEntity",
                newName: "RepoId");
        }
    }
}
