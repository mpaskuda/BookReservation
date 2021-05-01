using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReservationAPI.Repository
{
    public class ReservationRepository : IReservationRepository<ReservationModel>
    {
        private readonly ReservationContext _reservsationContext;

        public ReservationRepository(ReservationContext context)
        {
            _reservsationContext = context;
        }

        public void Add(ReservationModel entity)
        {
            _reservsationContext.Reservations.Add(entity);
            _reservsationContext.SaveChanges();
        }

        public void Delete(ReservationModel entity)
        {
            _reservsationContext.Reservations.Remove(entity);
            _reservsationContext.SaveChanges();
        }

        public ReservationModel Get(int id, int id2)
        {
            return _reservsationContext.Reservations.Where(a => a.BookID == id).FirstOrDefault(b => b.UserID == id2);
        }

        public IEnumerable<ReservationModel> GetAll(int id)
        {
            return _reservsationContext.Reservations.Where(a => a.BookID == id).ToList();
        }

        public void Update(ReservationModel dbEntity, ReservationModel entity)
        {
            dbEntity.UserID = entity.UserID;
            dbEntity.BookID = entity.BookID;
            dbEntity.ReservationDate = entity.ReservationDate;
            _reservsationContext.SaveChanges();
        }
    }
}