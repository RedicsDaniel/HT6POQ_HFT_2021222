using HT6POQ_HTF_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HFT_2021222.Repository.Data
{
    public class BookDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        public BookDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("books").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(book => book.Author).
                WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(book => book.Shop).
                WithMany(shop => shop.Books).
                HasForeignKey(book => book.ShopId).
                OnDelete(DeleteBehavior.Cascade);
            });

            #region authors
            Author a1 = new Author() { Id = 1, Age = 20, Name = "Aaron Ramsey", Nationality = "cseh", NumberOfBooks = 2 };
            Author a2 = new Author() { Id = 2, Age = 30, Name = "Peter Wright", Nationality = "lengyel", NumberOfBooks = 3 };
            Author a3 = new Author() { Id = 3, Age = 40, Name = "Lindsey Lohan", Nationality = "amerikai", NumberOfBooks = 5 };
            Author a4 = new Author() { Id = 4, Age = 60, Name = "Agatha Christie", Nationality = "angol", NumberOfBooks = 4 };
            Author a5 = new Author() { Id = 5, Age = 80, Name = "Marlon Adam", Nationality = "német", NumberOfBooks = 3 };
            #endregion
            #region shops
            Shop s1 = new Shop() { Id = 1, Name = "Boulvar", Location = "Budapest" };
            Shop s2 = new Shop() { Id = 2, Name = "Paul Street", Location = "London" };
            Shop s3 = new Shop() { Id = 3, Name = "Elm Street", Location = "Bukarest" };
            Shop s4 = new Shop() { Id = 4, Name = "Madame", Location = "Rejkjavik" };
            Shop s5 = new Shop() { Id = 5, Name = "LM Store", Location = "Tampa" };
            #endregion
            #region books
            Book b1 = new Book() { Id = 1, Title = "Halott város", PageNumber = 300, Type = BookType.Horror,AuthorId = 2,ShopId =s1.Id,Price = 500  };
            Book b2 = new Book() { Id = 2, Title = "Ego hatalma", PageNumber = 340, Type = BookType.Classic,AuthorId = 3,ShopId = s2.Id, Price = 1500 };
            Book b3 = new Book() { Id = 3, Title = "Ember a Holdon", PageNumber = 100, Type = BookType.Comic,AuthorId = 4, ShopId = s3.Id, Price = 2500 };
            Book b4 = new Book() { Id = 4, Title = "Sherlock Holmes", PageNumber = 500, Type = BookType.Detective, AuthorId =5 ,ShopId = s5.Id, Price = 5500 };
            Book b5 = new Book() { Id = 5, Title = "Egy kutya 7 élete", PageNumber = 80, Type = BookType.Fantasy , AuthorId = 3,ShopId = s2.Id, Price = 10500 };
            Book b6 = new Book() { Id = 5, Title = "Holtodiglan", PageNumber = 180, Type = BookType.Mystery, AuthorId = 1, ShopId = s2.Id, Price = 4500 };
            #endregion

            modelBuilder.Entity<Author>().HasData(a1, a2, a3, a4, a5);
            modelBuilder.Entity<Shop>().HasData(s1, s2, s3, s4, s5);
            modelBuilder.Entity<Book>().HasData(b1, b2, b3, b4, b5);
        }


    }
}
