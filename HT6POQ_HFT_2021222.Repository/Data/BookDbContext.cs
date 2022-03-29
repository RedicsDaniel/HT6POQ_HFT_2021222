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
            }
            );
        }
    }
}
