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
using NUnit.Framework;

namespace EnduranceGoals.Tests
{


    [TestFixture]
    internal class DBPopulateFields : NHibernateInMemoryTestFixtureBase
    {

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
        }

        [Test]
        public void RepopulateDatabase()
        {
            Execute();
            Assert.IsTrue(true);
        }

        public void Execute()
        {
            //DeleteData();
            PopulateData();
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
            TruncateTable("GoalParticipants");

            TruncateTable("Goals");
            TruncateTable("Venues");
            TruncateTable("Cities");
            TruncateTable("Countries");

            TruncateTable("Users");
        }

        private void TruncateTable(string tableName)
        {

            //ExecuteSql("delete from " + tableName);
            //ObjectContext a = new ObjectContext(entity.Connection.ConnectionString);
            //a.DeleteObject();


            //using (entity)
            //{
            //    IDbConnection conn = (entity.Connection as EntityConnection).StoreConnection;
            //    conn.Open();
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "delete from " + tableName;
            //        cmd.ExecuteReader();
            //    }
            //}


            //var command = entity.Connection.CreateCommand();
            //entity.Connection.Open();
            //command.CommandText = @"DELETE FROM GoalParticipants where  UserId != 'a'";
            //command.ExecuteNonQuery();

            //var ex = entity.CreateQuery<EnduranceGoalsEntities>("DELETE FROM " + tableName);
            //entity.SaveChanges();
        }

        public void CreateCountries()
        {
            NHibernateProfiler.Initialize();
            using (var transation = session.BeginTransaction())
            {
                var countryRepository = new CountryRepository(session);
                var countryList = new[]
                                      {
                                          CreateCountry("A"),
                                          CreateCountry("A"),
                                          CreateCountry("A"),
                                          CreateCountry("Spain2"),
                                          CreateCountry("United Sates3"),
                                          CreateCountry("Philippines4")
                                      };

                foreach (var country in countryList)
                {
                    countryRepository.Add(country);
                }
                try
                {
                    transation.Commit();


                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    var inner = ex.InnerException.Message;
                    throw;
                }
                
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
    }

    internal class CountryRepository : ICountryRepository
    {
        private readonly ISession session;

        public CountryRepository(ISession _session)
        {
            session = _session;
        }

        public void Add(Country country)
        {
            try
            {
            session.Save(country);
                session.Flush();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var inner = ex.InnerException;
                throw;
            }
            
        }

        public void Update(Country country)
        {
            throw new NotImplementedException();
        }

        public void Remove(Country country)
        {
            throw new NotImplementedException();
        }

        public Country GetById(Guid countryId)
        {
            throw new NotImplementedException();
        }

        public Country GetByName(string countryName)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository
    {
        void Add(Country country);
        void Update(Country country);
        void Remove(Country country);
        Country GetById(Guid countryId);
    }

    public interface ICountryRepository : IRepository
    {
        Country GetByName(string countryName);
    }
}
