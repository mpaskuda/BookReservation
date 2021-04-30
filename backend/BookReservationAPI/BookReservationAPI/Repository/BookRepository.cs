using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReservationAPI.Repository
{
    public class BookRepository : IBookRepository<BookModel>
    {
        private readonly BookContext _bookContext;

        public BookRepository(BookContext context)
        {
            _bookContext = context;
        }

        public void Add(BookModel entity)
        {
            _bookContext.Books.Add(entity);
            _bookContext.SaveChanges();
        }

        public void Delete(BookModel entity)
        {
            _bookContext.Books.Remove(entity);
            _bookContext.SaveChanges();
        }

        public BookModel Get(int id)
        {
            return _bookContext.Books.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<BookModel> GetAll()
        {
            return _bookContext.Books.ToList();
        }

        public void Update(BookModel dbEntity, BookModel entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Author = entity.Author;
            dbEntity.Description = entity.Description;
            dbEntity.Description = entity.Description;

            _bookContext.SaveChanges();

        }
    }
}
