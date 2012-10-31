using System;
using System.Collections.Generic;
using NHibernate;

namespace EnduranceGoals.Models.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ISession session;

        public Repository(ISession _session)
        {
            session = _session;
        }

        public void Add(T entity)
        {
            session.Save(entity);
            session.Flush();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            session.Delete(entity);
            session.Flush();
        }

        public T GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return session.QueryOver<T>().List();
        }
    }
}
