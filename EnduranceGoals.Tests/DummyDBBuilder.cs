using System;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using NHibernate;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    public class DummyDBBuilder
    {
        private Countries countries;
        private Cities cities;
        private Venues venues;
        private Users users;
        private Sports sports;
        private Goals goals;
        private ISessionFactory sessionFactory;
        private ISession session;

        public DummyDBBuilder()
        {
            Initialize();
        }

        public void BuildDB()
        {
            DeleteAllData();
            PopulateData();
            Assert.IsTrue(true);
        }

        private void Initialize()
        {
            sessionFactory =  SessionFactoryBuilder.SessionFactory;
            session = sessionFactory.OpenSession();

            countries = new Countries(session);
            cities = new Cities(session);
            venues = new Venues(session);
            users = new Users(session);
            sports = new Sports(session);
            goals = new Goals(session);
        }

        private void PopulateData()
        {
            CreateCountries();
            CreateCities();
            CreateVenues();
            CreateUsers();
            CreateSports();
            CreateGoals();
            CreateGoalParticipants();
        }

        private void DeleteAllData()
        {
            var typeList = new[]
                               {                         
                                   typeof(GoalParticipant),                               
                                   typeof(Goal),                               
                                   typeof(Venue),                               
                                   typeof(City),                               
                                   typeof(Country),                               
                                   typeof(Sport),                               
                                   typeof(User)
                               };

            foreach (var type in typeList)
            {
                DeleteTable(type.ToString());
            }
        }
        private void DeleteTable(string tableName)
        {
            using (var transation = session.BeginTransaction())
            {
                var deleteTableQuery = string.Format("delete from {0}", tableName);
                session.CreateQuery(deleteTableQuery).ExecuteUpdate();
                transation.Commit();
            }
            session.Clear();
        }

        private void CreateCountries()
        {
            using (var transation = session.BeginTransaction())
            {
                
                var countryList = new[]
                                      {
                                          CreateCountry("Spain"),
                                          CreateCountry("United Sates"),
                                          CreateCountry("Philippines"),
                                          CreateCountry("France")
                                      };

                foreach (var country in countryList)
                {
                    countries.Add(country);
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

        private void CreateCities()
        {
            using (var transation = session.BeginTransaction())
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
                                       CreateCity("Niza", "France"),
                                   };

                foreach (var city in cityList)
                {
                    cities.Add(city);
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
                           Country = countries.GetByName(countryName)
                       };
        }

        private void CreateVenues()
        {
            using (var transation = session.BeginTransaction())
            {
                var venueList = new[]
                                    {
                                        CreateVenue("Bernabeu", "Madrid", 1, 1),
                                        CreateVenue("Calderon", "Madrid", 1, 1),
                                        CreateVenue("Manzanares", "Madrid", 1, 1),
                                        CreateVenue("Atocha", "Madrid", 1, 1),
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
                                        CreateVenue("Catedral", "Burgos", 4, 4),
                                        CreateVenue("Niza Beach","Niza",2,2)
                                    };

                foreach (var venue in venueList)
                {
                    venues.Add(venue);
                }
                transation.Commit();
            }
            session.Clear();
        }
        private Venue CreateVenue(string venueName, string cityName, double latitude, double longitude)
        {
            return new Venue()
                       {
                           Name = venueName,
                           Latitude = latitude,
                           Longitude = longitude,
                           City = cities.GetByName(cityName)
                       };
        }

        private void CreateUsers()
        {
            using (var transation = session.BeginTransaction())
            {
                var userList = new[]
                                   {
                                       CreateUser("juan.huerta@gmail.com", "Juan", "Huerta", "jhuerta", "password", DateTime.Now),
                                       CreateUser("lucas.fernandez@gmail.com", "Lucas", "Fernandez", "lfernandez",
                                                  "password", DateTime.Now),
                                       CreateUser("irene.fernadez@hotmail.com", "Irene", "Fernandez", "ifernandez",
                                                  "password", DateTime.Now),
                                       CreateUser("hasmin.gelera@yahoo.com", "Hasmin", "Gelera", "hgelera", "password", DateTime.Now),
                                       CreateUser("shr1818@gmail.com", "Santiago", "Huerta", "shuerta", "password", DateTime.Now),
                                       CreateUser("me@u-journal.org", "Unai", "Rodriguez", "urodriguez", "password", DateTime.Now),
                                        CreateUser("user_only_participant_not_creator@u-journal.org", "Only Participant In Special Testing Event", "Only Participant In Special Testing Event", "uniqueparticipant", "unique_participant", DateTime.Now),
                                       CreateUser("user_only_participant_not_creator@u-journal.org", "Only Participant In Special Testing Event", "Only Participant In Special Testing Event", "uniquecreator", "uniquecreator", DateTime.Now)
                                   };

                foreach (var user in userList)
                {
                    users.Add(user);
                }
                transation.Commit();
            }
            session.Clear();
        }
        private User CreateUser(string email, string name, string lastname, string username, string password, DateTime createdOn)
        {
            return new User()
                       {
                           Email = email,
                           Name = name,
                           Lastname = lastname,
                           Username = username,
                           Password = password,
                           CreatedOn = createdOn
                       };
        }
        
        private Sport CreateSport(string name)
        {
            return new Sport()
                       {
                           Name = name
                       };
        }
        private void CreateSports()
        {
            using (var transation = session.BeginTransaction())
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
                                        CreateSport("Special Event 1 Participant"),
                                    };

                foreach (var sport in sportList)
                {
                    sports.Add(sport);
                }
                transation.Commit();
            }
            session.Clear();
        }

        private void CreateGoals()
        {
            using (var transation = session.BeginTransaction())
            {
                var goalList = new[]
                                   {
                                       CreateGoal(new DateTime(2014, 1, 18), "www.ironmanworldchampionship.com",
                                                  "Ironman World Championship", new DateTime(2012, 1, 10), "jhuerta",
                                                  "Kailua Beach", "The best moment of the year!", "Triathlon - Ironman")
                                       , CreateGoal(new DateTime(2014, 2, 18), "www.ironmanniza.com",
                                                    "Ironman Niza", new DateTime(2012, 1, 11), "jhuerta",
                                                    "Niza Beach", "Figth the best of the best in France",
                                                    "Triathlon - Ironman"),
                                       CreateGoal(new DateTime(2014, 2, 10), "www.bostonmarathon.com", "Boston Marathon",
                                                  new DateTime(2012, 1, 11), "jhuerta", "Ciy up and down",
                                                  "All the best marathoners of the world together in one event!",
                                                  "Marathon"),
                                       CreateGoal(new DateTime(2014, 2, 25), "www.ny703.com", "New York 70.3",
                                                  new DateTime(2012, 4, 20), "lfernandez", "5th Avenue",
                                                  "Amazing landscape for amazing event", "Triathlon - 70.3"),
                                       CreateGoal(new DateTime(2014, 3, 1), "www.madridvallecana.com",
                                                  "San Silvestre Vallecana", new DateTime(2012, 5, 1), "ifernandez",
                                                  "Casa de Campo", "Run the city with us", "10K"),
                                       CreateGoal(new DateTime(2014, 6, 5), "www.burgosduatlon.es", "Duatlon de Burgos",
                                                  new DateTime(2012, 6, 2), "jhuerta", "Catedral",
                                                  "A super duatlon around the city", "Triathlon - Olympic"),
                                       CreateGoal(new DateTime(2015, 1, 1), "www.tnfbaguio.com", "The North Face Baguio",
                                                  new DateTime(2012, 10, 10), "urodriguez", "Camp John Hay",
                                                  "Enjoy running in the city", "Ultramarathon - Trail"),
                                       CreateGoal(new DateTime(2015, 2, 1), "www.manilatriayala.com",
                                                  "Manila Trialon Ayala", new DateTime(2012, 11, 1), "shuerta",
                                                  "Manila Bay", "No fear, tri in the city", "Triathlon - Sprint"),
                                       CreateGoal(new DateTime(2015, 4, 1), "www.maratonfortbonifacio.com",
                                                  "Fort Bonifacio Run", new DateTime(2012, 11, 1), "urodriguez",
                                                  "Fort Bonifacio", "First marathon in the heart of the city",
                                                  "Half Maraton"),
                                       CreateGoal(new DateTime(2015, 4, 1), "www.special1participant.com",
                                                  "Special Event 1 Participant", new DateTime(2012, 11, 1), "urodriguez",
                                                  "Fort Bonifacio",
                                                  "This event contains one participant. The participant is not the creator.",
                                                  "Half Maraton"),
                                       CreateGoal(new DateTime(2015, 4, 1), "www.noparticipantsOnlyCreator.com",
                                                  "Special Event No Participant Only Creator", new DateTime(2012, 11, 1),
                                                  "uniquecreator",
                                                  "Fort Bonifacio", "No Participants - Only Creator",
                                                  "Half Maraton")
                                   };

                foreach (var goal in goalList)
                {
                    goals.Add(goal);
                }
                transation.Commit();
            }
            session.Clear();
            
        }
        private Goal CreateGoal(DateTime date, string web, string title, DateTime createdOn, string createdBy, string venueName, string description, string sport)
        {
            return new Goal()
                       {
                           Date = date,
                           Web = web,
                           Name = title,
                           CreatedOn = createdOn,
                           UserCreator = GetUser(createdBy),
                           Venue = venues.GetByName(venueName),
                           Description = description,
                           Sport = sports.GetByName(sport)
                       };
        }

        private void CreateGoalParticipants()
        {
            using (var transation = session.BeginTransaction())
            {
                var GoalParticipantsList = new[]
                                              {
                                                  CreateGoalParticipant("jhuerta", "Ironman World Championship", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "Boston Marathon", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "New York 70.3", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "San Silvestre Vallecana", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "Duatlon de Burgos", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "The North Face Baguio", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "Manila Trialon Ayala", DateTime.Now),
                                                  CreateGoalParticipant("jhuerta", "Fort Bonifacio Run", DateTime.Now),
                                                  CreateGoalParticipant("lfernandez", "Ironman World Championship", DateTime.Now),
                                                  CreateGoalParticipant("ifernandez", "Boston Marathon", DateTime.Now),
                                                  CreateGoalParticipant("shuerta", "New York 70.3", DateTime.Now),
                                                  CreateGoalParticipant("shuerta", "San Silvestre Vallecana", DateTime.Now),
                                                  CreateGoalParticipant("urodriguez", "Duatlon de Burgos", DateTime.Now),
                                                  CreateGoalParticipant("hgelera", "The North Face Baguio", DateTime.Now),
                                                  CreateGoalParticipant("hgelera", "Manila Trialon Ayala", DateTime.Now),
                                                  CreateGoalParticipant("lfernandez", "Fort Bonifacio Run", DateTime.Now),
                                                  CreateGoalParticipant("uniqueparticipant", "Special Event 1 Participant", DateTime.Now),


                                              };

                foreach (var gp in GoalParticipantsList)
                {
                    gp.User.AddGoal(
                        gp.Goal, gp.SignedOnDate);
                }
                transation.Commit();
            }
            session.Clear();
        }

        private GoalParticipant CreateGoalParticipant(string username, string goalname, DateTime date)
        {
            return new GoalParticipant
                       {
                           User = GetUser(username),
                           Goal = GetGoal(goalname),
                           SignedOnDate = date
                       };
        }

        private User GetUser(string userName)
        {
            return users.GetByUserName(userName);
        }

        private Goal GetGoal(string goalName)
        {
            return goals.GetByName(goalName);
        }
    }

}