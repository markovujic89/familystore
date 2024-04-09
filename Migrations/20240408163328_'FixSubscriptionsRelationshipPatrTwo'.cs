using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyStore.Migrations
{
    /// <inheritdoc />
    public partial class FixSubscriptionsRelationshipPatrTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Companies_CompanyId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_CompanyId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subscriptions");

            migrationBuilder.CreateTable(
                name: "CompanySubscription",
                columns: table => new
                {
                    CompanySubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySubscription", x => new { x.CompanySubscriptionsId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_CompanySubscription_Companies_CompanySubscriptionsId",
                        column: x => x.CompanySubscriptionsId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanySubscription_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionUser",
                columns: table => new
                {
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false),
                    UserSubscriptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionUser", x => new { x.SubscriptionsId, x.UserSubscriptionsId });
                    table.ForeignKey(
                        name: "FK_SubscriptionUser_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionUser_Users_UserSubscriptionsId",
                        column: x => x.UserSubscriptionsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscription_SubscriptionsId",
                table: "CompanySubscription",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUser_UserSubscriptionsId",
                table: "SubscriptionUser",
                column: "UserSubscriptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanySubscription");

            migrationBuilder.DropTable(
                name: "SubscriptionUser");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CompanyId",
                table: "Subscriptions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Companies_CompanyId",
                table: "Subscriptions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
