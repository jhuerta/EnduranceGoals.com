using System;
using System.Linq;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    public class MSSQL_DatabaseTest : DBTestBase
    {
        protected Users users;
        protected Goals goals;
        protected Sports sports;
        protected Venues venues;
        protected Cities cities;
        protected Countries countries;

        [SetUp]
        public void Setup()
        {
            NHibernateProfiler.Initialize();
            RecreateDB();
            users = new Users(session);
            goals = new Goals(session);
            sports = new Sports(session);
            venues = new Venues(session);
            cities = new Cities(session);
            countries = new Countries(session);
        }
    }

    [TestFixture]
    public class SportRepositoryTest : MSSQL_DatabaseTest
    {
        [Test]
        public void Cannot_delete_sport_if_it_still_used_by_goal()
        {
            using (var transation = session.BeginTransaction())
            {
 
                var existingSport = sports.GetAll().First();
                var goalWithExistingSport = goals.GetAllBySport(existingSport).First();

                Assert.That(goalWithExistingSport.Id, Is.GreaterThan(0));

                Assert.Throws<ObjectDeletedException>(delegate
                {
                    sports.Remove(existingSport);
                    transation.Commit();
                });
            }
            session.Clear();
        }
    }
    
    [TestFixture]
    public class UserRepositoryTest : MSSQL_DatabaseTest
    {
        [Test]
        public void Cannot_delete_user_if_it_created_a_goal_and_the_goal_exists()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingUser = users.GetAll().First();
                var goalWithExistingUserCreator = goals.GetAllByUserCreator(existingUser).First();

                Assert.That(goalWithExistingUserCreator.Id, Is.GreaterThan(0));

                Assert.Throws<ObjectDeletedException>(delegate
                                                          {
                                                              users.Remove(existingUser);
                                                              transation.Commit();
                                                          });
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_participant_if_the_participant_is_still_registered_to_a_goal()
        {
            using (var transation = session.BeginTransaction())
            {

                var uniqueParticipantInEvent_NotCreator = users.GetAll()
                    .Where(u => u.Username == "uniqueparticipant")
                    .Single();

                var goalWithOnlyOneParticipant =
                    goals.GetAllByParticipant(uniqueParticipantInEvent_NotCreator).First();

                // Asserting the goal exist (it has been prepared)
                Assert.That(goalWithOnlyOneParticipant.Id, Is.GreaterThan(0));

                // Asserting creator is different from participant
                string usernameUniqueParticipant = goalWithOnlyOneParticipant.Participants.First().User.Username;
                string usernameCreator = goalWithOnlyOneParticipant.UserCreator.Username;
                Assert.That(usernameUniqueParticipant, Is.Not.EqualTo(usernameCreator));

                Assert.Throws<ObjectDeletedException>(delegate
                                                          {
                                                              users.Remove(uniqueParticipantInEvent_NotCreator);
                                                              transation.Commit();
                                                          });
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_user_if_the_user_is_still_the_creator_of_a_goal()
        {
            using (var transation = session.BeginTransaction())
            {
                var uniqueCreator_NoParticipant = users.GetAll().Where(u => u.Username == "uniquecreator").Single();

                var goalWithNoParticipantsOnlyCreator = goals.GetAllByCreator(uniqueCreator_NoParticipant).First();

                Assert.That(goalWithNoParticipantsOnlyCreator.Id, Is.GreaterThan(0));

                Assert.Throws<ObjectDeletedException>(delegate
                {
                    users.Remove(uniqueCreator_NoParticipant);
                    transation.Commit();
                });
            }
            session.Clear();
        }
    }

    [TestFixture]
    public class VenueRepositoryTest : MSSQL_DatabaseTest
    {
        [Test]
        public void Cannot_delete_venue_if_it_still_used_by_goal()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingVenue = venues.GetByName("Kailua Beach");
                var goalWithExistingVenue= goals.GetAllByVenue(existingVenue).First();

                Assert.That(goalWithExistingVenue.Id, Is.GreaterThan(0));

                Assert.Throws<ObjectDeletedException>(delegate
                {
                    venues.Remove(existingVenue);
                    transation.Commit();
                });
            }
            session.Clear();
        }
    }

    [TestFixture]
    public class CityRepositoryTest : MSSQL_DatabaseTest
    {
        [Test]
        public void Cannot_delete_city_if_it_still_used_by_venue()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingCity = cities.GetAll().First();
                var venueWithExistingCity = venues.GetAllByCity(existingCity).First();

                Assert.That(venueWithExistingCity.Id, Is.GreaterThan(0));

                Assert.Throws<ObjectDeletedException>(delegate
                {
                    cities.Remove(existingCity);
                    transation.Commit();
                });
            }
            session.Clear();
        }

        [Test]
        public void A_city_has_venues()
        {
            var venuesOfMadrid = cities.GetByName("Madrid").Venues;

            Assert.That(venuesOfMadrid.Count, Is.GreaterThan(1));
        }
    }

    [TestFixture]
    public class CountryRepositoryTest : MSSQL_DatabaseTest
    {
        [Test]
        public void Cannot_delete_country_if_it_still_used_by_city()
        {
            using (var transation = session.BeginTransaction())
            {
                var existingCountry = countries.GetAll().First();

                var cityWithExistingCountry = cities.GetAllByCountry(existingCountry).First();

                Assert.That(cityWithExistingCountry.Id, Is.GreaterThan(0));

                Assert.Throws<ObjectDeletedException>(delegate
                {
                    countries.Remove(existingCountry);
                    transation.Commit();
                });
            }
            session.Clear();
        }

        [Test]
        public void A_country_has_cities()
        {
            var citiesOfSpain = countries.GetByName("Spain").Cities;

            Assert.That(citiesOfSpain.Count, Is.GreaterThan(1));
        }
    }

    [TestFixture]
    public class GoalRepositoryTest : MSSQL_DatabaseTest
    {
       [Test]
        public void Cannot_delete_goal_if_it_still_has_participants_registered_to_it()
        {
            using (var transation = session.BeginTransaction())
            {
                var existingGoal = goals.GetAll().First();

                var participantWithAtLeastExistingGoal = users.GetAllByGoals(existingGoal).First();

                // Assert the goal has participants subscribed to it
                Assert.That(participantWithAtLeastExistingGoal.Id, Is.GreaterThan(0));

                // Assert we cant delete the goal
                Assert.Throws<ObjectDeletedException>(delegate
                {
                        goals.Remove(existingGoal);
                        transation.Commit();
                });
            }
            session.Clear();
        }
    }
}