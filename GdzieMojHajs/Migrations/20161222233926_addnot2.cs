using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GdzieMojHajs.Migrations
{
    public partial class addnot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NotificationReceiverId = table.Column<int>(nullable: false),
                    NotificationSenderId = table.Column<int>(nullable: false),
                    Seen = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_UserProfileInfo_NotificationReceiverId",
                        column: x => x.NotificationReceiverId,
                        principalTable: "UserProfileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_UserProfileInfo_NotificationSenderId",
                        column: x => x.NotificationSenderId,
                        principalTable: "UserProfileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "DebtId",
                table: "Notification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_DebtId",
                table: "Notification",
                column: "DebtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Debt_DebtId",
                table: "Notification",
                column: "DebtId",
                principalTable: "Debt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
