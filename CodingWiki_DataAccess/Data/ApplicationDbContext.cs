using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingWiki_DataAccess.FluentConfig;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        //rename to Fluent_BookDetails
        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Author { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-U57R7FL;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    IDBook = 1,
                    Title = "Amintiri din copilarie",
                    ISBN = "CreangaFilms",
                    Price = 12.99m,
                    Publisher_Id = 1
                },
                 new Book
                 {
                     IDBook = 2,
                     Title = "Luceafarul",
                     ISBN = "CreangaFilms",
                     Price = 15.99m,
                     Publisher_Id = 1
                 });
                
            var bookList = new Book[]
            {
                new Book { IDBook = 3, Title = "Hanul Ancutei", ISBN ="FDSF#", Price = 9.99m, Publisher_Id=1},
                new Book { IDBook = 4, Title = "Sara pe Deal", ISBN ="FDSF#", Price = 10.99m, Publisher_Id=2},
                new Book { IDBook = 5, Title = "Harap Alb", ISBN ="FDSF#", Price = 11.99m, Publisher_Id=3}
            };
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData( 
            new Publisher { Publisher_Id = 1, Name = "Pub1", Location = "Carei"},
            new Publisher { Publisher_Id = 2, Name = "Pub2", Location = "Cluj-Napoca" },
            new Publisher { Publisher_Id = 3, Name = "Pub3", Location = "Constanta"}
            );

        }

    }
}
