using System;
using System.Collections.Generic;

namespace EnduranceGoals.Models.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(Guid entityId);
        IList<T> GetAll();
    }
}