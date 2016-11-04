using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GdzieMojHajs.Models;

namespace GdzieMojHajs.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160316203317_Database2.0")]
    partial class Database20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("GdzieMojHajs.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int?>("UserProfileInfoId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("GdzieMojHajs.Models.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DebtOwnerId");

                    b.Property<int>("DebtReceiverId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GdzieMojHajs.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DebtId");

                    b.Property<int>("NotificationReceiverId");

                    b.Property<int>("NotificationSenderId");

                    b.Property<bool>("Seen");

                    b.Property<string>("Text");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GdzieMojHajs.Models.UserProfileInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowsToMigrateDebts");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("GdzieMojHajs.Models.ApplicationUser", b =>
                {
                    b.HasOne("GdzieMojHajs.Models.UserProfileInfo")
                        .WithMany()
                        .HasForeignKey("UserProfileInfoId");
                });

            modelBuilder.Entity("GdzieMojHajs.Models.Debt", b =>
                {
                    b.HasOne("GdzieMojHajs.Models.UserProfileInfo")
                        .WithMany()
                        .HasForeignKey("DebtOwnerId");

                    b.HasOne("GdzieMojHajs.Models.UserProfileInfo")
                        .WithMany()
                        .HasForeignKey("DebtReceiverId");
                });

            modelBuilder.Entity("GdzieMojHajs.Models.Notification", b =>
                {
                    b.HasOne("GdzieMojHajs.Models.Debt")
                        .WithMany()
                        .HasForeignKey("DebtId");

                    b.HasOne("GdzieMojHajs.Models.UserProfileInfo")
                        .WithMany()
                        .HasForeignKey("NotificationReceiverId");

                    b.HasOne("GdzieMojHajs.Models.UserProfileInfo")
                        .WithMany()
                        .HasForeignKey("NotificationSenderId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GdzieMojHajs.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GdzieMojHajs.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.Microsoft.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("GdzieMojHajs.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
