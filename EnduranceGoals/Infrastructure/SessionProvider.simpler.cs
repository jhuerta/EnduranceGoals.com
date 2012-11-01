using System;
using System.IO;
using EnduranceGoals.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;

namespace EnduranceGoals.Infrastructure
{
    public static class SessionProvider
    {
        private static ISessionFactory sessionFactory { get; set; }
        private static FluentConfiguration configuration;

        public static ISessionFactory SessionFactory
        {
            get {
                return BuildSessionFactory();
            }
        }
        private static ISessionFactory BuildSessionFactory()
        {
            try
            {
                if (sessionFactory == null)
                {
                    sessionFactory = Configuration.BuildSessionFactory();
                }

                return sessionFactory;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var innermsg = ex.InnerException.Message;
                throw;
            }
        }

        private static FluentConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {

                    var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnduranceGoals.cfg.xml");

                    Configuration nhconfig = new Configuration().Configure(configFile);

                    //setup the fluent map configuration
                    configuration = Fluently.Configure(nhconfig).Mappings(m => m.FluentMappings
                                                                          .AddFromAssemblyOf<Goal>()
                                                                          .Conventions.Add(ForeignKey.Format((p, t) => t.Name + "Id")));
                }

                return configuration;
            }
        }

        public static ISession Session
        {
            get { return SessionFactory.OpenSession(); }
        }
    }



}