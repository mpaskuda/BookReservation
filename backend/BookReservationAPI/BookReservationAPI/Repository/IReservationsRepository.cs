﻿using System.Collections.Generic;

namespace BookReservationAPI.Repository
{
    public interface IReservationRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}