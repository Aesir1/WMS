using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseInfrastructure.Migrations
{
    public partial class UserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Dimension_DimensionCodeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Heaviness_HeavinessCodeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Address_AddressCodeId",
                table: "Containers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heaviness",
                table: "Heaviness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimension",
                table: "Dimension");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Heaviness",
                newName: "Heavinesses");

            migrationBuilder.RenameTable(
                name: "Dimension",
                newName: "Dimensions");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heavinesses",
                table: "Heavinesses",
                column: "CodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions",
                column: "CodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "CodeId");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserManager = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<bool>(type: "bit", nullable: false),
                    Create = table.Column<bool>(type: "bit", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Users_Permissions_PermissionGuid",
                        column: x => x.PermissionGuid,
                        principalTable: "Permissions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserInfos_Guid",
                        column: x => x.Guid,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentUser",
                columns: table => new
                {
                    DepartmentsGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentUser", x => new { x.DepartmentsGuid, x.UsersGuid });
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Departments_DepartmentsGuid",
                        column: x => x.DepartmentsGuid,
                        principalTable: "Departments",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Users_UsersGuid",
                        column: x => x.UsersGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_UsersGuid",
                table: "DepartmentUser",
                column: "UsersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionGuid",
                table: "Users",
                column: "PermissionGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Dimensions_DimensionCodeId",
                table: "Articles",
                column: "DimensionCodeId",
                principalTable: "Dimensions",
                principalColumn: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Heavinesses_HeavinessCodeId",
                table: "Articles",
                column: "HeavinessCodeId",
                principalTable: "Heavinesses",
                principalColumn: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Addresses_AddressCodeId",
                table: "Containers",
                column: "AddressCodeId",
                principalTable: "Addresses",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Dimensions_DimensionCodeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Heavinesses_HeavinessCodeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Addresses_AddressCodeId",
                table: "Containers");

            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heavinesses",
                table: "Heavinesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Heavinesses",
                newName: "Heaviness");

            migrationBuilder.RenameTable(
                name: "Dimensions",
                newName: "Dimension");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heaviness",
                table: "Heaviness",
                column: "CodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimension",
                table: "Dimension",
                column: "CodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Dimension_DimensionCodeId",
                table: "Articles",
                column: "DimensionCodeId",
                principalTable: "Dimension",
                principalColumn: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Heaviness_HeavinessCodeId",
                table: "Articles",
                column: "HeavinessCodeId",
                principalTable: "Heaviness",
                principalColumn: "CodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Address_AddressCodeId",
                table: "Containers",
                column: "AddressCodeId",
                principalTable: "Address",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
