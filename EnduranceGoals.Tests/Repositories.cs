using System;
using System.Collections.Generic;
using System.Linq;
using EnduranceGoals.Models;
using FluentNHibernate;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Criterion;

namespace EnduranceGoals.Tests
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

    public class RepositoryWithName<Entity> : Repository<Entity>, IRepositoryWithName<Entity> where Entity : class
    {
        public RepositoryWithName(ISession _session)
            : base(_session)
        {
        }

        public Entity GetByName(string entityName)
        {
            return session.CreateCriteria<Entity>()
                .Add(Restrictions.Eq("Name", entityName))
                .UniqueResult<Entity>();
        }
    }

    public class UserGoals : Repository<UserGoal>, IUserGoalsRepository
    {
        public UserGoals(ISession _session)
            : base(_session)
        {
        }
    }
    public class Goals : RepositoryWithName<Goal>, IGoalsRepository
    {
        public Goals(ISession _session)
            : base(_session)
        {
        }

        public IList<Goal> GetAllBySport(Sport sport)
        {
            return session.CreateCriteria<Goal>()
                .Add(Restrictions.Eq("Sport", sport)).List<Goal>();
        }

        public IList<Goal> GetAllByUserCreator(User user)
        {

            return session.CreateCriteria<Goal>()
                .Add(Restrictions.Eq("UserCreator", user)).List<Goal>();
        }

        public IList<Goal> GetAllByVenue(Venue venue)
        {
            return session.CreateCriteria<Goal>()
                .Add(Restrictions.Eq("Venue", venue)).List<Goal>();
        }

        public IList<Goal> GetAllByParticipant(User participant)
        {
            return session.CreateCriteria(typeof (Goal))
                .CreateCriteria("UserGoals")
                .Add(Expression.Eq("User", participant))
                .List<Goal>();
        }

        public IList<Goal> GetAllByCreator(User creator)
        {
            return session.CreateCriteria(typeof(Goal))
                .CreateCriteria("UserCreator")
                .Add(Expression.Eq("Id", creator.Id))
                .List<Goal>();
        }
    }

    public class Sports : RepositoryWithName<Sport>, ISports
    {
        public Sports(ISession _session)
            : base(_session)
        {
        }

    }
    public class Users : RepositoryWithName<User>, IUsersRepository
    {
        public Users(ISession _session)
            : base(_session)
        {
        }

        public User GetByUserName(string userName)
        {
            return session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Username", userName))
                .UniqueResult<User>();
        }

        public ICollection<User> GetAllByGoals(Goal goal)
        {
            return session.CreateCriteria(typeof(User))
                .CreateCriteria("Goals")
                .Add(Expression.Eq("Id", goal.Id))
                .List<User>();
        }
    }

    public class Venues : RepositoryWithName<Venue>, IVenueRepository
    {
        public Venues(ISession _session)
            : base(_session)
        {
        }

        public IList<Venue> GetAllByCity(City city)
        {
            return session.CreateCriteria<Venue>()
                .Add(Restrictions.Eq("City", city)).List<Venue>();
        }
    }
    public class Cities : RepositoryWithName<City>, ICityRepository
    {
        public Cities(ISession _session)
            : base(_session)
        {
        }

        public IList<City> GetAllByCountry(Country country)
        {
            return session.CreateCriteria<City>()
                .Add(Restrictions.Eq("Country", country)).List<City>();
        }
    }
    public class Countries : RepositoryWithName<Country>
    {
        public Countries(ISession _session)
            : base(_session)
        {
        }
    }
}
