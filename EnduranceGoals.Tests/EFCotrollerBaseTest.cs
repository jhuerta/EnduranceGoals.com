using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using EnduranceGoals.Controllers;
using EnduranceGoals.Models;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{


    [TestFixture]
    internal class DBPopulateFields : NHibernateInMemoryTestFixtureBase
    {
        private CountryRepository countryRepository;
        private CityRepository cityRepository;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            InitalizeSessionFactory(
                typeof(Country).Assembly,
                typeof(Goal).Assembly,
                typeof(User).Assembly,
                typeof(Venue).Assembly,
                typeof(Country).Assembly,
                typeof(Sport).Assembly);

                countryRepository = new CountryRepository(session);
                cityRepository = new CityRepository(session);
        }

        [Test]
        public void RepopulateDatabase()
        {
            Execute();
            Assert.IsTrue(true);
        }

        public void Execute()
        {
            DeleteData();
            //PopulateData();
        }

        public void PopulateData()
        {
            CreateCountries();
            CreateCities();
            //CreateVenues();
            //CreateUsers();
            //CreateSports();
            //CreateGoals();
            //CreateGoalParticipants();
        }

        public void DeleteData()
        {
            DeleteTable("goals");
            DeleteTable("venues");
            DeleteTable("cities");
            DeleteTable("countries");
            DeleteTable("sports");
            DeleteTable("users");
        }

        private void DeleteTable(string tableName)
        {
            NHibernateProfiler.Initialize();
            using (var transation = session.BeginTransaction())
            {
                var deleteTableQuery = string.Format("delete from {0}", tableName);
                session.CreateQuery(deleteTableQuery).ExecuteUpdate();
                transation.Commit();
            }
            session.Clear();
        }

        public void CreateCountries()
        {
            // NHibernateProfiler.Initialize();
            using (var transation = session.BeginTransaction())
            {
                
                var countryList = new[]
                                      {
                                          CreateCountry("Spain"),
                                          CreateCountry("United Sates"),
                                          CreateCountry("Philippines")
                                      };

                foreach (var country in countryList)
                {
                    countryRepository.Add(country);
                }
                
                transation.Commit();
            }

            session.Clear();
        }
        private static Country CreateCountry(string countryName)
        {
            return new Country()
                       {
                           Name = countryName
                       };
        }

        public void CreateCities()
        {
            NHibernateProfiler.Initialize();
            using (var transation = session.BeginTransaction())
            {
                var cityRepository = new CityRepository(session);
                var cityList = new[]
                               {
                                   CreateCity("Madrid", "Spain"),
                                   CreateCity("Barcelona", "Spain"),
                                   CreateCity("Burgos", "Spain"),
                                   CreateCity("Zaragoza", "Spain"),
                                   CreateCity("New York", "United Sates"),
                                   CreateCity("Kona", "United Sates"),
                                   CreateCity("Boston", "United Sates"),
                                   CreateCity("Camarines Sur", "Philippines"),
                                   CreateCity("Manila", "Philippines"),
                                   CreateCity("Baguio", "Philippines"),
                               };

                foreach (var city in cityList)
                {
                    cityRepository.Add(city);
                }
                transation.Commit();
            }
            session.Clear();
        }

        private City CreateCity(string cityName, string countryName)
        {
            return new City()
            {
                Name = cityName,
                Country = GetCountry(countryName)
            };
        }

        private Country GetCountry(string countryName)
        {
            var country = countryRepository.GetByName(countryName);
            return country;
        }
    }

    internal class CityRepository: ICityRepository
    {
        private readonly ISession session;

        public CityRepository(ISession _session)
        {
            session = _session;
        }

        public void Add(City entity)
        {
            session.Save(entity);
            session.Flush();
        }

        public void Update(City entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(City entity)
        {
            throw new NotImplementedException();
        }

        public City GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }

    internal interface ICityRepository : IRepository<City>{}

    internal class CountryRepository : ICountryRepository
    {
        private readonly ISession session;

        public CountryRepository(ISession _session)
        {
            session = _session;
        }

        public void Add(Country entity)
        {
            session.Save(entity);
            session.Flush();
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Country entity)
        {
            throw new NotImplementedException();
        }

        public Country GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Country GetByName(string countryName)
        {
            return session.CreateCriteria<Country>()
                .Add(Restrictions.Eq("Name", countryName))
                .UniqueResult<Country>();
        }
    }

    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(Guid entityId);
    }

    public interface ICountryRepository : IRepository<Country>
    {
        Country GetByName(string countryName);
    }
}
