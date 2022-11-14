using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContextChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Addresses_AddressCodeId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Articles_ArticleGuid",
                table: "Containers");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Addresses_AddressCodeId",
                table: "Containers",
                column: "AddressCodeId",
                principalTable: "Addresses",
                principalColumn: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Articles_ArticleGuid",
                table: "Containers",
                column: "ArticleGuid",
                principalTable: "Articles",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Addresses_AddressCodeId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Articles_ArticleGuid",
                table: "Containers");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Addresses_AddressCodeId",
                table: "Containers",
                column: "AddressCodeId",
                principalTable: "Addresses",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Articles_ArticleGuid",
                table: "Containers",
                column: "ArticleGuid",
                principalTable: "Articles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
