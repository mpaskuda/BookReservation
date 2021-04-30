// Wymagana jest instalacja paczki Microsfot.EntityFrameworkCore
using BookReservationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReservationAPI.DatabaseContext
{
    public class BookContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasData(
                new BookModel
                {
                    Id = 1,
                    Name = "asda",
                    Author = "asdasd",


                    ReleaseDate = new System.DateTime(2010, 1, 2),

                    Description = "Świetna książka!"
                },
                new BookModel
                {
                    Id = 2,
                    Name = "asda",
                    Author = "asdasd",
                    ReleaseDate = new System.DateTime(2000, 3, 24),

                    Description = "Taka sobie"
                });
        }


        public DbSet<BookReservationAPI.Models.BookModel> BookModels { get; set; }
    }
}
