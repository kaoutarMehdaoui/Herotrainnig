﻿// <auto-generated />
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230613161807_Seed data-Power")]
    partial class SeeddataPower
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.HeroPower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HerosId")
                        .HasColumnType("int");

                    b.Property<int>("PowersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HerosId");

                    b.HasIndex("PowersId");

                    b.ToTable("HeroPower");
                });

            modelBuilder.Entity("Domain.Models.Heros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameHero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heros");
                });

            modelBuilder.Entity("Domain.Models.Powers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Powers");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Invisibility"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shapeshifting"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Healing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Super Speed"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Super Strength"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Under Water Control"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Telekinesis "
                        },
                        new
                        {
                            Id = 9,
                            Name = "Elemental Control"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Mind Control"
                        });
                });

            modelBuilder.Entity("Domain.Models.HeroPower", b =>
                {
                    b.HasOne("Domain.Models.Heros", "Heros")
                        .WithMany("HeroPowers")
                        .HasForeignKey("HerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Powers", "Powers")
                        .WithMany("HeroPowers")
                        .HasForeignKey("PowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Heros");

                    b.Navigation("Powers");
                });

            modelBuilder.Entity("Domain.Models.Heros", b =>
                {
                    b.Navigation("HeroPowers");
                });

            modelBuilder.Entity("Domain.Models.Powers", b =>
                {
                    b.Navigation("HeroPowers");
                });
#pragma warning restore 612, 618
        }
    }
}
