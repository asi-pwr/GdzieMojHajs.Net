using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace GdzieMojHajs.Migrations
{
    public partial class Database21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Debt_UserProfileInfo_DebtOwnerId", table: "Debt");
            migrationBuilder.DropForeignKey(name: "FK_Debt_UserProfileInfo_DebtReceiverId", table: "Debt");
            migrationBuilder.DropForeignKey(name: "FK_Notification_Debt_DebtId", table: "Notification");
            migrationBuilder.DropForeignKey(name: "FK_Notification_UserProfileInfo_NotificationReceiverId", table: "Notification");
            migrationBuilder.DropForeignKey(name: "FK_Notification_UserProfileInfo_NotificationSenderId", table: "Notification");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddForeignKey(
                name: "FK_Debt_UserProfileInfo_DebtOwnerId",
                table: "Debt",
                column: "DebtOwnerId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Debt_UserProfileInfo_DebtReceiverId",
                table: "Debt",
                column: "DebtReceiverId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Debt_DebtId",
                table: "Notification",
                column: "DebtId",
                principalTable: "Debt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Notification_UserProfileInfo_NotificationReceiverId",
                table: "Notification",
                column: "NotificationReceiverId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Notification_UserProfileInfo_NotificationSenderId",
                table: "Notification",
                column: "NotificationSenderId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Debt_UserProfileInfo_DebtOwnerId", table: "Debt");
            migrationBuilder.DropForeignKey(name: "FK_Debt_UserProfileInfo_DebtReceiverId", table: "Debt");
            migrationBuilder.DropForeignKey(name: "FK_Notification_Debt_DebtId", table: "Notification");
            migrationBuilder.DropForeignKey(name: "FK_Notification_UserProfileInfo_NotificationReceiverId", table: "Notification");
            migrationBuilder.DropForeignKey(name: "FK_Notification_UserProfileInfo_NotificationSenderId", table: "Notification");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddForeignKey(
                name: "FK_Debt_UserProfileInfo_DebtOwnerId",
                table: "Debt",
                column: "DebtOwnerId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Debt_UserProfileInfo_DebtReceiverId",
                table: "Debt",
                column: "DebtReceiverId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Debt_DebtId",
                table: "Notification",
                column: "DebtId",
                principalTable: "Debt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Notification_UserProfileInfo_NotificationReceiverId",
                table: "Notification",
                column: "NotificationReceiverId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Notification_UserProfileInfo_NotificationSenderId",
                table: "Notification",
                column: "NotificationSenderId",
                principalTable: "UserProfileInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
