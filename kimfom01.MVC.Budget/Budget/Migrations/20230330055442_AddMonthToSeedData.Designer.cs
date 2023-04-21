﻿// <auto-generated />
using System;
using Budget.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Budget.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    [Migration("20230330055442_AddMonthToSeedData")]
    partial class AddMonthToSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Budget.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Housing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Insurance"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Medical & Healthcare"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Saving, Investing & Dept Payments"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Personal Spending"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Recreation & Entertainment"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("Budget.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cost")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("WalletId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Cost = 500.00m,
                            Date = new DateTime(2023, 3, 30, 8, 54, 42, 354, DateTimeKind.Local).AddTicks(4854),
                            Description = "I bought a new laptop, external keyboard and mouse",
                            Month = 3,
                            Name = "Computer Accessories",
                            WalletId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Cost = 150.00m,
                            Date = new DateTime(2023, 3, 30, 8, 54, 42, 354, DateTimeKind.Local).AddTicks(4906),
                            Description = "I bought a bunch of bananas, grapes and 7 oranges",
                            Month = 3,
                            Name = "Weekly fruit stocking",
                            WalletId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Cost = 150.00m,
                            Date = new DateTime(2023, 3, 30, 8, 54, 42, 354, DateTimeKind.Local).AddTicks(4920),
                            Description = "Went to assist Dominion in her cake business",
                            Month = 3,
                            Name = "Trip to Belgorod",
                            WalletId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 5,
                            Cost = 300.00m,
                            Date = new DateTime(2023, 3, 30, 8, 54, 42, 354, DateTimeKind.Local).AddTicks(4934),
                            Description = "Paid Annual Health Insurance",
                            Month = 3,
                            Name = "Annual Health Insurance",
                            WalletId = 2
                        });
                });

            modelBuilder.Entity("Budget.Models.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Balance")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Expenses")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Income")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wallets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 4200m,
                            Expenses = 800m,
                            Income = 5000.00m,
                            Name = "Test Wallet"
                        },
                        new
                        {
                            Id = 2,
                            Balance = 4700.00m,
                            Expenses = 300m,
                            Income = 5000.00m,
                            Name = "Main Wallet"
                        });
                });

            modelBuilder.Entity("Budget.Models.Transaction", b =>
                {
                    b.HasOne("Budget.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Budget.Models.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Budget.Models.Category", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Budget.Models.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
