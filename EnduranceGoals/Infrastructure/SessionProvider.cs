using System;
using System.IO;
using EnduranceGoals.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;

namespace EnduranceGoals.Infrastructure
{
    public sealed class SessionProvider
    {
        private readonly ISessionFactory sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get { return Instance.sessionFactory; }
        }

        public static SessionProvider Instance
        {
            get { return NestedSessionProvider.sessionManager; }
        }

        public static ISession CurrentSession
        {
            get { return SessionFactory.GetCurrentSession(); }
        }

        public static ISession CurrentSessionOrNew
        {
            get
            {
                if (NHibernate.Context.CurrentSessionContext.HasBind(SessionFactory))
                {
                    return CurrentSession; ;
                }
                return OpenSession();

            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private SessionProvider()
        {
            if (sessionFactory == null)
            {
                FluentConfiguration configuration;

                if (AppDomain.CurrentDomain.BaseDirectory.Contains(".Tests"))
                {
                    /* Build here the configruation for unit test*/
                    configuration = NUnitConfiguration;
                }
                else
                {
                    configuration = FluentConfiguration;
                }

                //Configuration configuration = new Configuration().Configure();
                if (configuration == null)
                {
                    throw new InvalidOperationException("NHibernate configuration is null.");
                }
                else
                {
                    sessionFactory = configuration.BuildSessionFactory();
                    if (sessionFactory == null)
                    {
                        throw new InvalidOperationException("Call to BuildSessionFactory() returned null.");
                    }
                }
            }
        }

        class NestedSessionProvider
        {
            internal static readonly SessionProvider sessionManager = new SessionProvider();
        }

        private static FluentConfiguration FluentConfiguration
        {
            get
            {
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnduranceGoals.cfg.xml");

                Configuration nhconfig = new Configuration().Configure(configFile);

                return Fluently.Configure(nhconfig).Mappings(
                    m => m.FluentMappings
                             .AddFromAssemblyOf<Goal>()
                             .Conventions.Add(ForeignKey.Format((p, t) => t.Name + "Id")));
            }
        }

        private static FluentConfiguration NUnitConfiguration{
            
            get
            {
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnduranceGoals.cfg.unit_test.xml");

                Configuration nhconfig = new Configuration().Configure(configFile);

                return Fluently.Configure(nhconfig).Mappings(
                    m => m.FluentMappings
                             .AddFromAssemblyOf<Goal>()
                             .Conventions.Add(ForeignKey.Format((p, t) => t.Name + "Id")));
            }
        }

        
    }
}