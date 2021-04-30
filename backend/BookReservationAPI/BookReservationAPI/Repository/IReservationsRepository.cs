using System.Collections.Generic;

namespace BookReservationAPI.Repository
{
    public interface IReservationRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(int id);
        TEntity Get(int id,int id2);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
