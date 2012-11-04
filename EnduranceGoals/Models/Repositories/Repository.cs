using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Data;
using NHibernate;


namespace EnduranceGoals.Models.Repositories
{

    /* The current implementation allows to implement the transaction or not.
     * 
     * PersonDAOImpl daoPerson = new PersonDAOImpl(m_session);
     *      using (var tx = m_session.BeginTransaction()) {
     *          Person newPerson = daoPerson.Save(_person);
     *          tx.Commit();}
     * 
     *  OR
     *  
     * PersonDAOImpl daoPerson = new PersonDAOImpl(m_session);
     * Person newPerson = daoPerson.Save(_person);
     * 
     * */

    public class Repository<TEntity> : IDelete<TEntity>, IRead<TEntity>, ISave<TEntity> where TEntity : class
    {
        protected readonly ISession session;

        public Repository(ISession Session)
        {
            session = Session;
        }

        public TEntity GetById(int ID)
        {
            if (!session.Transaction.IsActive)
            {
                TEntity retval;
                using (var tx = session.BeginTransaction())
                {
                    retval = session.Get<TEntity>(ID);
                    tx.Commit();
                    return retval;
                }
            }
            else
            {
                return session.Get<TEntity>(ID);
            }
        }

        public IList<TEntity> GetAll()
        {
            if (!session.Transaction.IsActive)
            {
                IList<TEntity> retval;
                using (var tx = session.BeginTransaction())
                {
                    retval = session.QueryOver<TEntity>().List();
                    tx.Commit();
                    return retval;
                }
            }
            else
            {
                return session.QueryOver<TEntity>().List();
            }
        }

        public IList<TEntity> GetByCriteria(ICriteria criteria)
        {
            if (!session.Transaction.IsActive)
            {
                IList<TEntity> retval;
                using (var tx = session.BeginTransaction())
                {
                    retval = criteria.List<TEntity>();
                    tx.Commit();
                    return retval;
                }
            }
            else
            {
                return criteria.List<TEntity>();
            }
        }

        public IList<TEntity> GetByQueryable(IQueryable<TEntity> queryable)
        {
            if (!session.Transaction.IsActive)
            {
                IList<TEntity> retval;
                using (var tx = session.BeginTransaction())
                {
                    retval = queryable.ToList<TEntity>();
                    tx.Commit();
                    return retval;
                }
            }
            else
            {
                return queryable.ToList<TEntity>();
            }
        }

        public TEntity Add(TEntity entity)
        {
            if (!session.Transaction.IsActive)
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit();
                }
            }
            else
            {
                session.SaveOrUpdate(entity);
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            if (!session.Transaction.IsActive)
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(entity);
                    tx.Commit();
                }
            }
            else
            {
                session.Delete(entity);
            }
        }

        public TEntity Update(TEntity entity)
        {
            if (!session.Transaction.IsActive)
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Merge(entity);
                    tx.Commit();
                }
            }
            else
            {
                session.Merge(entity);
            }
            return entity;
        }
    }

    public interface ISave<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
    }

    public interface IDelete<TEntity>
    {
        void Remove(TEntity entity);
    }


    public interface IRead<TEntity>
    {
        IList<TEntity> GetByQueryable(IQueryable<TEntity> queryable);
        IList<TEntity> GetByCriteria(ICriteria criteria);
        TEntity GetById(int ID);
        IList<TEntity> GetAll();
    }
}


//namespace EnduranceGoals.Models.Repositories
//{
//    public abstract class Repository<T> : IRepository<T> where T : class
//    {
//        protected readonly ISession session;

//        public Repository(ISession _session)
//        {
//            session = _session;
//        }

//        public void Add(T entity)
//        {
//            session.Save(entity);
//            session.Flush();
//        }

//        public void Update(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(T entity)
//        {
//            session.Delete(entity);
//            session.Flush();
//        }

//        public T GetById(Guid entityId)
//        {
//            throw new NotImplementedException();
//        }

//        public IList<T> GetAll()
//        {
//            return session.QueryOver<T>().List();
//        }
//    }
//}
