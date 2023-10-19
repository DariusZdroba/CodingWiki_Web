using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-U57R7FL;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    IDBook = 1,
                    Title = "Amintiri din copilarie",
                    ISBN = "CreangaFilms",
                    Price = 12.99m
                },
                 new Book
                 {
                     IDBook = 2,
                     Title = "Luceafarul",
                     ISBN = "CreangaFilms",
                     Price = 15.99m
                 });
                
            var bookList = new Book[]
            {
                new Book { IDBook = 3, Title = "Hanul Ancutei", ISBN ="FDSF#", Price = 9.99m},
                new Book { IDBook = 4, Title = "Sara pe Deal", ISBN ="FDSF#", Price = 10.99m},
                new Book { IDBook = 5, Title = "Harap Alb", ISBN ="FDSF#", Price = 11.99m}
            };
            modelBuilder.Entity<Book>().HasData(bookList);

        }

    }
}
