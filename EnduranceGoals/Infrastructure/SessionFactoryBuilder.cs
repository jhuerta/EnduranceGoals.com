using System;
using System.IO;
using EnduranceGoals.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;

namespace EnduranceGoals.Infrastructure
{
    public static class SessionFactoryBuilder
    {
        private static ISessionFactory _sessionFactory { get; set; }
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
                if (_sessionFactory != null)
                    return _sessionFactory;

                //setup the normal map configuration
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnduranceGoals.cfg.xml");
                Configuration nhconfig = new Configuration().Configure(configFile);

                //setup the fluent map configuration
                configuration = Fluently.Configure(nhconfig).Mappings(m => m.FluentMappings
                                                                               .AddFromAssemblyOf<Goal>()
                                                                               .Conventions.Add(
                                                                                   ForeignKey.Format(
                                                                                       (p, t) => t.Name + "Id")));

                // Use this to recreate a phisical database
                // CreatePhisycalDatabase(configuration);

                return configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var innermsg = ex.InnerException.Message;
                throw;
            }
        }
    }
}