using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Norm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministrativeUnit = table.Column<string>(maxLength: 255, nullable: true),
                    Value = table.Column<float>(nullable: false),
                    NewValue = table.Column<float>(nullable: false),
                    DateNewValueApply = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionDescription = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    PassportId = table.Column<string>(maxLength: 14, nullable: true),
                    AdministrativeUnit = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 13, nullable: true),
                    FamilyComposition = table.Column<int>(nullable: false),
                    NormId = table.Column<int>(nullable: true),
                    PersonsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Norm_NormId",
                        column: x => x.NormId,
                        principalTable: "Norm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonArea = table.Column<double>(nullable: false),
                    LivingArea = table.Column<double>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    TypeOfProperty = table.Column<string>(maxLength: 255, nullable: true),
                    StateOfProperty = table.Column<string>(maxLength: 255, nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estates_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    DateTimeOfRequest = table.Column<DateTime>(nullable: false),
                    StateOfRequest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRequests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    PersonRequestsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queues_PersonRequests_PersonRequestsId",
                        column: x => x.PersonRequestsId,
                        principalTable: "PersonRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPersonRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PersonRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPersonRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPersonRequests_PersonRequests_PersonRequestId",
                        column: x => x.PersonRequestId,
                        principalTable: "PersonRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPersonRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_PersonId",
                table: "Estates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRequests_PersonId",
                table: "PersonRequests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NormId",
                table: "Persons",
                column: "NormId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonsId",
                table: "Persons",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_PersonRequestsId",
                table: "Queues",
                column: "PersonRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_RoleId",
                table: "RolesPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_PermissionId_RoleId",
                table: "RolesPermissions",
                columns: new[] { "PermissionId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPersonRequests_PersonRequestId",
                table: "UsersPersonRequests",
                column: "PersonRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPersonRequests_UserId_PersonRequestId",
                table: "UsersPersonRequests",
                columns: new[] { "UserId", "PersonRequestId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId_RoleId",
                table: "UsersRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "Queues");

            migrationBuilder.DropTable(
                name: "RolesPermissions");

            migrationBuilder.DropTable(
                name: "UsersPersonRequests");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PersonRequests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Norm");
        }
    }
}
