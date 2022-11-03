using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseInfrastructure.Migrations
{
    public partial class StorageDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    CodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.CodeId);
                });

            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    CodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false),
                    Width = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.CodeId);
                });

            migrationBuilder.CreateTable(
                name: "Heaviness",
                columns: table => new
                {
                    CodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heaviness", x => x.CodeId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimensionCodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HeavinessCodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Articles_Dimension_DimensionCodeId",
                        column: x => x.DimensionCodeId,
                        principalTable: "Dimension",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Articles_Heaviness_HeavinessCodeId",
                        column: x => x.HeavinessCodeId,
                        principalTable: "Heaviness",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    ContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    AddressCodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArticleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.ContainerId);
                    table.ForeignKey(
                        name: "FK_Containers_Address_AddressCodeId",
                        column: x => x.AddressCodeId,
                        principalTable: "Address",
                        principalColumn: "CodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Containers_Articles_ArticleGuid",
                        column: x => x.ArticleGuid,
                        principalTable: "Articles",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DimensionCodeId",
                table: "Articles",
                column: "DimensionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_HeavinessCodeId",
                table: "Articles",
                column: "HeavinessCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_AddressCodeId",
                table: "Containers",
                column: "AddressCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ArticleGuid",
                table: "Containers",
                column: "ArticleGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Dimension");

            migrationBuilder.DropTable(
                name: "Heaviness");
        }
    }
}
