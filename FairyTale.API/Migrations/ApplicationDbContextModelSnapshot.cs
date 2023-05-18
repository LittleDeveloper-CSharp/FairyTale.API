﻿// <auto-generated />
using System;
using FairyTale.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FairyTale.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FairyTale.API.Models.Dwarf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SnowWhiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SnowWhiteId");

                    b.ToTable("Dwarfs");
                });

            modelBuilder.Entity("FairyTale.API.Models.DwarfTransferRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedRequestSnowWhiteId")
                        .HasColumnType("int");

                    b.Property<int?>("DungeonMasterSnowWhiteId")
                        .HasColumnType("int");

                    b.Property<int>("DwarfId")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CreatedRequestSnowWhiteId");

                    b.HasIndex("DungeonMasterSnowWhiteId");

                    b.HasIndex("DwarfId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("FairyTale.API.Models.SnowWhite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SnowWhites");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Белоснежка"
                        });
                });

            modelBuilder.Entity("FairyTale.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SnowWhiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SnowWhiteId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FairyTale.API.Models.Dwarf", b =>
                {
                    b.HasOne("FairyTale.API.Models.SnowWhite", "SnowWhite")
                        .WithMany("Dwarfs")
                        .HasForeignKey("SnowWhiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SnowWhite");
                });

            modelBuilder.Entity("FairyTale.API.Models.DwarfTransferRequest", b =>
                {
                    b.HasOne("FairyTale.API.Models.SnowWhite", "CreatedRequestSnowWhite")
                        .WithMany("CreatedRequests")
                        .HasForeignKey("CreatedRequestSnowWhiteId");

                    b.HasOne("FairyTale.API.Models.SnowWhite", "DungeonMasterSnowWhite")
                        .WithMany("Requests")
                        .HasForeignKey("DungeonMasterSnowWhiteId");

                    b.HasOne("FairyTale.API.Models.Dwarf", "Dwarf")
                        .WithMany()
                        .HasForeignKey("DwarfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedRequestSnowWhite");

                    b.Navigation("DungeonMasterSnowWhite");

                    b.Navigation("Dwarf");
                });

            modelBuilder.Entity("FairyTale.API.Models.User", b =>
                {
                    b.HasOne("FairyTale.API.Models.SnowWhite", "SnowWhite")
                        .WithMany()
                        .HasForeignKey("SnowWhiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SnowWhite");
                });

            modelBuilder.Entity("FairyTale.API.Models.SnowWhite", b =>
                {
                    b.Navigation("CreatedRequests");

                    b.Navigation("Dwarfs");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}