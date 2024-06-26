﻿// <auto-generated />
using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231023110354_maxLengthAndNotMappedInBooksTable")]
    partial class maxLengthAndNotMappedInBooksTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Property<int>("IDBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDBook"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDBook");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            IDBook = 1,
                            ISBN = "CreangaFilms",
                            Price = 12.99m,
                            Title = "Amintiri din copilarie"
                        },
                        new
                        {
                            IDBook = 2,
                            ISBN = "CreangaFilms",
                            Price = 15.99m,
                            Title = "Luceafarul"
                        },
                        new
                        {
                            IDBook = 3,
                            ISBN = "FDSF#",
                            Price = 9.99m,
                            Title = "Hanul Ancutei"
                        },
                        new
                        {
                            IDBook = 4,
                            ISBN = "FDSF#",
                            Price = 10.99m,
                            Title = "Sara pe Deal"
                        },
                        new
                        {
                            IDBook = 5,
                            ISBN = "FDSF#",
                            Price = 11.99m,
                            Title = "Harap Alb"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
