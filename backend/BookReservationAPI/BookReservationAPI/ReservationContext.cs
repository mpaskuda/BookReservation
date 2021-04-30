// Wymagana jest instalacja paczki Microsfot.EntityFrameworkCore
using BookReservationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReservationAPI.DatabaseContext
{
    public class ReservationContext : DbContext
    {
        public DbSet<ReservationModel> Reservations { get; set; }

        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationModel>().HasData(
                new ReservationModel
                {
                    UserID = 1,
                    BookID = 1,


                    ReservationDate = new System.DateTime(2012, 1, 2),

                },
                new ReservationModel
                {
                    UserID = 2,
                    BookID = 2,

                    ReservationDate = new System.DateTime(2010, 3, 24),

                });
        }
        public DbSet<BookReservationAPI.Models.ReservationModel> ReservationModels { get; set; }
    }
}
