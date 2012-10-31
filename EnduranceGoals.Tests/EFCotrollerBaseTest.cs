using System;
using System.Linq;
using EnduranceGoals.Models;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    public class MSSQL_DatabaseTest : DBTestBase
    {
        private Users users;
        private Goals goals;
        private Sports sports;
        private Venues venues;
        private Cities cities;
        private Countries countries;

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

        [Test]
        public void Cannot_delete_sport_if_it_still_used_by_goal()
        {
            using (var transation = session.BeginTransaction())
            {
 
                var existingSport = sports.GetAll().First();
                var goalWithExistingSport = goals.GetAllBySport(existingSport).First();

                Assert.That(goalWithExistingSport.Id, Is.GreaterThan(0));

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                                                     {
                                                         sports.Remove(existingSport);
                                                         transation.Commit();
                                                     });
                var innerException = exception.InnerException;

                Assert.That(innerException.Message.Contains("FK_Goals_SportId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_user_if_it_still_used_by_goal()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingUser = users.GetAll().First();
                var goalWithExistingUserCreator = goals.GetAllByUserCreator(existingUser).First();

                Assert.That(goalWithExistingUserCreator.Id, Is.GreaterThan(0));

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    users.Remove(existingUser);
                    transation.Commit();
                });
                var innerException = exception.InnerException;

                Assert.That(innerException.Message.Contains("FK_Goals_UserCreatorId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_venue_if_it_still_used_by_goal()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingVenue = venues.GetAll().First();
                var goalWithExistingVenue= goals.GetAllByVenue(existingVenue).First();

                Assert.That(goalWithExistingVenue.Id, Is.GreaterThan(0));

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    venues.Remove(existingVenue);
                    transation.Commit();
                });

                var innerException = exception.InnerException;
                Assert.That(innerException.Message.Contains("FK_Goals_VenueId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_city_if_it_still_used_by_venue()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingCity = cities.GetAll().First();
                var venueWithExistingCity = venues.GetAllByCity(existingCity).First();

                Assert.That(venueWithExistingCity.Id, Is.GreaterThan(0));

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    cities.Remove(existingCity);
                    transation.Commit();
                });

                var innerException = exception.InnerException;
                Assert.That(innerException.Message.Contains("FK_Venues_CityId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_country_if_it_still_used_by_city()
        {
            using (var transation = session.BeginTransaction())
            {

                var existingCountry = countries.GetAll().First();
                var cityWithExistingCountry = cities.GetAllByCountry(existingCountry).First();

                Assert.That(cityWithExistingCountry.Id, Is.GreaterThan(0));

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    countries.Remove(existingCountry);
                    transation.Commit();
                });

                var innerException = exception.InnerException;
                Assert.That(innerException.Message.Contains("FK_Cities_CountryId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
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

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    users.Remove(uniqueCreator_NoParticipant);
                    transation.Commit();
                });

                var innerException = exception.InnerException;
                Assert.That(innerException.Message.Contains("FK_Goals_UserCreatorId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
            }
            session.Clear();
        }

        [Test]
        public void Cannot_delete_goal_if_it_still_has_participants_registered_to_it()
        {
            //return;
            using (var transation = session.BeginTransaction())
            {

                var existingGoal = goals.GetAll().First();

                var participantWithAtLeastExistingGoal = users.GetAllByGoals(existingGoal).First();

                Assert.That(participantWithAtLeastExistingGoal.Id, Is.GreaterThan(0));

                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    try
                    {
                        goals.Remove(existingGoal);
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                        throw;
                    }
                    
                });

                transation.Commit();
                var innerException = exception.InnerException;
                Assert.That(innerException.Message.Contains("FK_GoalParticipants_GoalId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
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

                var goalWithOnlyOneParticipant = goals.GetAllByParticipant(uniqueParticipantInEvent_NotCreator).First();
             
                // Asserting the goal exist (it has been prepared)
                Assert.That(goalWithOnlyOneParticipant.Id, Is.GreaterThan(0));

                // Asserting creator is different from participant
                string usernameUniqueParticipant = goalWithOnlyOneParticipant.Participants.First().User.Username;
                string usernameCreator = goalWithOnlyOneParticipant.UserCreator.Username;
                Assert.That(usernameUniqueParticipant, Is.Not.EqualTo(usernameCreator));


                var exception = Assert.Throws<NHibernate.Exceptions.GenericADOException>(delegate
                {
                    try
                    {
                        users.Remove(uniqueParticipantInEvent_NotCreator);
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                        throw;
                    }
                    
                });

                transation.Commit();
                var innerException = exception.InnerException;
                Assert.That(innerException.Message.Contains("FK_GoalParticipants_UserId"));
                Assert.IsInstanceOf<System.Data.SqlClient.SqlException>(innerException);
            }
            session.Clear();
        }

    }
}
