using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReservationAPI.Repository
{
    public class UserRepository : IUserRepository<UserModel>
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext context)
        {
            _userContext = context;
        }

        public void Add(UserModel entity)
        {
            _userContext.Users.Add(entity);
            _userContext.SaveChanges();
        }

        public void Delete(UserModel entity)
        {
            _userContext.Users.Remove(entity);
            _userContext.SaveChanges();
        }

        public UserModel Get(int id)
        {
            return _userContext.Users.FirstOrDefault(a => a.Id == id);
        }

        public UserModel Auth(string aaa, string bbb)
        {
            return _userContext.Users.Where(a => a.Username == aaa).FirstOrDefault(b => b.Password == bbb);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public void Update(UserModel dbEntity, UserModel entity)
        {            
            dbEntity.Username = entity.Username;
            dbEntity.Password = entity.Password;
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;


            _userContext.SaveChanges();

        }
    }
}
