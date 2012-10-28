using System;
using System.Collections.Generic;
using EnduranceGoals.Models;
using System.Linq;

namespace EnduranceGoals.Tests
{
    public interface IRepositoryWithName<T>
    {
        T GetByName(string entityName);
    }

    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(Guid entityId);
        IList<T> GetAll();
    }

    internal interface IGoalParticipantsRepository
    {
    }

    internal interface IGoalsRepository
    {
        IList<Goal> GetAllBySport(Sport id);
        IList<Goal> GetAllByUserCreator(User user);
        IList<Goal> GetAllByParticipant(User participant);
        IList<Goal> GetAllByCreator(User creator);
    }
    public interface ISports
    {
    }
    public interface IUsersRepository
    {
        User GetByUserName(string userName);
        ICollection<User> GetAllByGoals(Goal goal);
    }
    public interface IVenueRepository
    {
        IList<Venue> GetAllByCity(City city);
    }
    public interface ICityRepository
    {
        IList<City> GetAllByCountry(Country country);
    }
    public interface ICountryRepository
    {
    }


}