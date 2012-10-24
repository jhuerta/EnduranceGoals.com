using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Text;
using EnduranceGoals.Controllers;
using EnduranceGoals.Models;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    public class TestInheritedClass : EFControllerBase
    {
        public bool CanReadEntity()
        {
            return entity.Users.Count() != 0;
        }

        public void CanWriteAndDeleteToEntity()
        {
            
            string testName = new Random().Next().ToString();
            var newUser = new Users
                           {
                               Email = "test@test.com",
                               Lastname = "Test",
                               Name = "Test",
                               Password = "Password",
                               Username = testName
                           };

            var numberUsersBeforeAdding = entity.Users.Count();
            entity.AddToUsers(newUser);
            
            
            try
            {
                entity.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            var numberUsersAfterAdding = entity.Users.Count();
            
            
            Assert.That(numberUsersAfterAdding,Is.EqualTo(numberUsersBeforeAdding+1));

            var lastUser = entity.Users.First(s => s.Username == testName);
            
            Assert.That(lastUser.Username, Is.EqualTo(testName));

            entity.DeleteObject(newUser);
            entity.SaveChanges();

            var numberUsersAfterDelete = entity.Users.Count();

            Assert.That(numberUsersAfterDelete, Is.EqualTo(numberUsersBeforeAdding));
       }
        
    }
    [TestFixture]
    class EFCotrollerBaseTest
    {
        [Test]
        public void BaseControllerCanReadFromEntity()
        {
            var testInheritedClass = new TestInheritedClass();
            Assert.That(testInheritedClass.CanReadEntity(), Is.True);
        }

        [Test]
        public void BaseControllerCanWriteFromEntity()
        {
            var testInheritedClass = new TestInheritedClass();
            testInheritedClass.CanWriteAndDeleteToEntity();
        }
     
    }

    [TestFixture]
    internal class DBPopulateFields : EFControllerBase
    {
        [Test]
        public void RepopulateDatabase()
        {
            Execute();
            Assert.IsTrue(true);
        }
        public void Execute()
        {
            DeleteData();
            PopulateData();
        }

        public void PopulateData()
        {
            CreateCountries();
            CreateCities();
            CreateVenues();
            CreateUsers();
            CreateSports();
            CreateGoals();
            CreateGoalParticipants();

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

            ExecuteSql("delete from " + tableName);
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

       

        public void CreateUsers()
        {
            var userList = new[]
                               {
                                   CreateUser("juan.huerta@gmail.com", "Juan", "Huerta", "jhuerta", "password", new DateTime(2011, 1, 10)),
                                   CreateUser("lucas.fernandez@gmail.com", "Lucas", "Fernandez", "lfernandez",
                                              "password", new DateTime(2010, 5, 18)),
                                   CreateUser("irene.fernadez@hotmail.com", "Irene", "Fernandez", "ifernandez",
                                              "password" , new DateTime(2012, 1, 25)),
                                   CreateUser("hasmin.gelera@yahoo.com", "Hasmin", "Gelera", "hgelera", "password", new DateTime(2012, 3, 18)),
                                   CreateUser("shr1818@gmail.com", "Santiago", "Huerta", "shuerta", "password", new DateTime(2011, 2, 18)),
                                   CreateUser("me@u-journal.org", "Unai", "Rodriguez", "urodriguez", "password", new DateTime(2010, 1, 25))
                               };

            foreach (var user in userList)
            {
                entity.AddToUsers(user);
            }
            entity.SaveChanges();
        }
        public void CreateCities()
        {
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
                entity.AddToCities(city);
            }
            entity.SaveChanges();
        }
        public void CreateCountries()
        {
            var countryList = new[]
                                  {
                                      CreateCountry("Spain"),
                                      CreateCountry("United Sates"),
                                      CreateCountry("Philippines")
                                  };

            var before = entity.Countries.Count();

            foreach (var country in countryList)
            {
                entity.AddToCountries(country);
            }

            var after = entity.Countries.Count();

            entity.SaveChanges();
        }
        public void CreateVenues()
        {
            var venueList = new[]
                                {
                                    CreateVenue("Manila Bay", "Manila", 1, 1),
                                    CreateVenue("Fort Bonifacio", "Manila", 2, 2),
                                    CreateVenue("Parque Gwell", "Barcelona", 3, 3),
                                    CreateVenue("Las Ramblas", "Barcelona", 4, 4),
                                    CreateVenue("Casa de Campo", "Madrid", 1, 2),
                                    CreateVenue("Lady Liberty", "New York", 1, 3),
                                    CreateVenue("5th Avenue", "New York", 2, 1),
                                    CreateVenue("Ciy up and down", "Boston", 2, 3),
                                    CreateVenue("Camp John Hay", "Baguio", 2, 4),
                                    CreateVenue("Kailua Beach", "Kona", 3, 4),
                                    CreateVenue("Catedral", "Burgos", 4, 4)
                                };

            foreach (var venue in venueList)
            {
                entity.AddToVenues(venue);
            }
            entity.SaveChanges();
        }

        public void CreateSports()
        {
            var sportList = new[]
                                {
                                    CreateSport("Triathlon - Ironman"),
                                    CreateSport("Triathlon - Olympic"),
                                    CreateSport("Triathlon - Sprint"),
                                    CreateSport("Triathlon - 70.3"),
                                    CreateSport("Marathon"),
                                    CreateSport("Half Maraton"),
                                    CreateSport("10K"),
                                    CreateSport("Ultramarathon - Trail"),
                                };

            foreach (var sport in sportList)
            {
                entity.AddToSports(sport);
            }
            entity.SaveChanges();
        }

        private Sports CreateSport(string name)
        {
            return new Sports()
                       {
                           Name = name
                       };
        }

        public void CreateGoals()
        {
            var goalList = new[] 
                               {
                                   CreateGoal(new DateTime(2014, 1, 18),"www.ironmanworldchampionship.com", "Ironman World Championship", new DateTime(2012,1,10),"jhuerta","Kailua Beach", "The best moment of the year!", "Triathlon - Ironman"),
                                   CreateGoal(new DateTime(2014, 2, 10),"www.bostonmarathon.com", "Boston Marathon", new DateTime(2012,1,11),"jhuerta","Ciy up and down", "All the best marathoners of the world together in one event!", "Marathon"),
                                   CreateGoal(new DateTime(2014, 2, 25),"www.ny703.com", "New York 70.3", new DateTime(2012,4,20),"lfernandez","5th Avenue", "Amazing landscape for amazing event", "Triathlon - 70.3"),
                                   CreateGoal(new DateTime(2014, 3, 1),"www.madridvallecana.com", "San Silvestre Vallecana", new DateTime(2012,5,1),"ifernandez","Casa de Campo", "Run the city with us", "10K"),
                                   CreateGoal(new DateTime(2014, 6, 5),"www.burgosduatlon.es", "Duatlon de Burgos", new DateTime(2012,6,2),"jhuerta","Catedral", "A super duatlon around the city", "Triathlon - Olympic"),
                                   CreateGoal(new DateTime(2015, 1, 1),"www.tnfbaguio.com", "The North Face Baguio", new DateTime(2012,10,10),"urodriguez","Camp John Hay", "Enjoy running in the city", "Ultramarathon - Trail"),
                                   CreateGoal(new DateTime(2015, 2, 1),"www.manilatriayala.com", "Manila Trialon Ayala", new DateTime(2012,11,1),"shuerta","Manila Bay", "No fear, tri in the city", "Triathlon - Sprint"),
                                   CreateGoal(new DateTime(2015, 4, 1),"www.maratonfortbonifacio.com", "Fort Bonifacio Run", new DateTime(2012,11,1),"urodriguez","Fort Bonifacio", "First marathon in the heart of the city", "Half Maraton")
                               };

            foreach (var goal in goalList)
            {
                entity.AddToGoals(goal);
            }
            entity.SaveChanges(); 
        }
        public void CreateGoalParticipants()
        {
            var goalParticipatnList = new[] 
                               {
                                   CreateGoalParticipant("jhuerta","Ironman World Championship", new DateTime(2012,5,10)),
                                   CreateGoalParticipant("jhuerta","Boston Marathon", new DateTime(2012,6,10)),
                                   CreateGoalParticipant("jhuerta","New York 70.3", new DateTime(2012,7,10)),
                                   CreateGoalParticipant("jhuerta","San Silvestre Vallecana", new DateTime(2012,9,1)),
                                   CreateGoalParticipant("jhuerta","Duatlon de Burgos", new DateTime(2012,1,25)),
                                   CreateGoalParticipant("jhuerta","The North Face Baguio", new DateTime(2012,10,6)),
                                   CreateGoalParticipant("jhuerta","Manila Trialon Ayala", new DateTime(2012,10,6)),
                                   CreateGoalParticipant("jhuerta","Fort Bonifacio Run", new DateTime(2013,5,10)),
                                   CreateGoalParticipant("lfernandez","Ironman World Championship", new DateTime(2013,5,11)),
                                   CreateGoalParticipant("ifernandez","Boston Marathon", new DateTime(2014,5,10)),
                                   CreateGoalParticipant("shuerta","New York 70.3", new DateTime(2014,7,11)),
                                   CreateGoalParticipant("shuerta","San Silvestre Vallecana", new DateTime(2012,2,1)),
                                   CreateGoalParticipant("urodriguez","Duatlon de Burgos", new DateTime(2012,2,2)),
                                   CreateGoalParticipant("hgelera","The North Face Baguio", new DateTime(2012,2,3)),
                                   CreateGoalParticipant("hgelera","Manila Trialon Ayala", new DateTime(2012,5,18)),
                                   CreateGoalParticipant("lfernandez","Fort Bonifacio Run", new DateTime(2012,10,10))
                               };

            foreach (var goalParticipant in goalParticipatnList)
            {
                entity.AddToGoalParticipants(goalParticipant);
            }
            entity.SaveChanges();
        }

        private GoalParticipants CreateGoalParticipant(string participantUserName, string goalName, DateTime signOndate)
        {
            return new GoalParticipants
                       {
                           Goals = GetGoal(goalName),
                           Users = GetUser(participantUserName),
                           SignedOnDate = signOndate
                       };
        }
        private Goals CreateGoal(DateTime date,string web, string title, DateTime createdOn, string createdBy, string venueName, string description, string sport)
        {
            return new Goals()
                       {
                           Date = date,
                           EventWeb = web,
                           Name = title,
                           CreatedOn = createdOn,
                           Users = GetUser(createdBy),
                           Venues = GetVenue(venueName),
                           Description = description,
                           Sports = GetSport(sport)
                       };
        }

        private Sports GetSport(string sport)
        {
            return entity.Sports.First(s => s.Name == sport);
        }

        private  Users CreateUser(string email, string name, string lastname, string username, string password, DateTime createdOn)
        {
            return new Users()
                       {
                           Email = email,
                           Name = name,
                           Lastname = lastname,
                           Username = username,
                           Password = password,
                           CreatedOn = createdOn
                       };
        }
        private Cities CreateCity(string cityName, string countryName)
        {
            return new Cities()
                       {
                           Name = cityName,
                           Countries = GetCountry(countryName)
                       };
        }
        private static Countries CreateCountry(string countryName)
        {
            return new Countries()
            {
                Name = countryName
            };
        }
        private Venues CreateVenue(string venueName, string cityName, double latitude, double longitude)
        {
            return new Venues()
                       {
                           Name = venueName,
                           Latitude = latitude,
                           Longitude = longitude,
                           Cities = GetCity(cityName)
                       };
        }

        private Cities GetCity(string cityName)
        {
            return entity.Cities.First(c => c.Name == cityName);
        }
        private Venues GetVenue(string venueName)
        {
            return entity.Venues.First(v => v.Name == venueName);
        }
        private Users GetUser(string userName)
        {
            return entity.Users.First(u => u.Username == userName);
        }
        private Goals GetGoal(string name)
        {
            return entity.Goals.First(g => g.Name == name);
        }
        private Countries GetCountry(string countryName)
        {
            return entity.Countries.First(c => c.Name == countryName);
        }
    }
}
