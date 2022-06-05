﻿// <auto-generated />
using System;
using BlackBoot.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlackBoot.Data.Migrations
{
    [DbContext(typeof(BlackBootDBContext))]
    partial class BlackBootDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlackBoot.Domain.Entities.CrowdSaleSchedule", b =>
                {
                    b.Property<int>("CrowdSaleScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrowdSaleScheduleId"), 1L, 1);

                    b.Property<int>("BonusCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvestmentGoal")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MinimumBuy")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<int>("TokenForSale")
                        .HasColumnType("int");

                    b.HasKey("CrowdSaleScheduleId");

                    b.ToTable("CrowdSaleSchedule", "Base");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsImportant")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)");

                    b.Property<byte>("Target")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Subscription", "Base");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BonusCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ConfirmDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CrowdSaleScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("CryptoAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Network")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("TokenCount")
                        .HasColumnType("int");

                    b.Property<string>("TxId")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<int>("UsdtAmount")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalletAddress")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("TransactionId");

                    b.HasIndex("CrowdSaleScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction", "Payment");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WithdrawalWallet")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("WithdrawalWallet")
                        .IsUnique()
                        .HasFilter("[WithdrawalWallet] IS NOT NULL");

                    b.ToTable("User", "Base");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("d0a569cf-aa3d-4631-a365-cf4693441ba3"),
                            BirthdayDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Admin@BlackBoot.io",
                            FullName = "Admin",
                            Gender = (byte)1,
                            IsActive = true,
                            Nationality = "",
                            Password = "SELEtxzRpGEVskq+ddvHykdlDA2P8hB/2UHoo0uquvc=",
                            RegistrationDate = new DateTime(2022, 6, 5, 15, 17, 20, 749, DateTimeKind.Local).AddTicks(9924)
                        });
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.UserJwtToken", b =>
                {
                    b.Property<int>("UserJwtTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserJwtTokenId"), 1L, 1);

                    b.Property<DateTimeOffset>("AccessTokenExpiresTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("AccessTokenHash")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTimeOffset>("RefreshTokenExpiresTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RefreshTokenHash")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserJwtTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("UserJwtToken", "Base");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.WalletPool", b =>
                {
                    b.Property<int>("WalletPoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalletPoolId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<byte>("Network")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WalletPoolId");

                    b.HasIndex("UserId");

                    b.ToTable("WalletPool", "Base");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.Notification", b =>
                {
                    b.HasOne("BlackBoot.Domain.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("BlackBoot.Domain.Entities.CrowdSaleSchedule", "CrowdSaleSchedule")
                        .WithMany()
                        .HasForeignKey("CrowdSaleScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackBoot.Domain.Entities.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CrowdSaleSchedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.UserJwtToken", b =>
                {
                    b.HasOne("BlackBoot.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.WalletPool", b =>
                {
                    b.HasOne("BlackBoot.Domain.Entities.User", "User")
                        .WithMany("WalletPools")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlackBoot.Domain.Entities.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Transactions");

                    b.Navigation("WalletPools");
                });
#pragma warning restore 612, 618
        }
    }
}
