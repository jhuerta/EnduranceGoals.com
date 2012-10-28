using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace EnduranceGoals.Tests
{
    public class NHibernateTestFixtureBase
    {
        protected static ISessionFactory sessionFactory;
        protected static FluentConfiguration configuration;
        public static ISession session;

        public void InitalizeSessionFactory(params Assembly[] assemblies)
        {
            try
            {


            if (sessionFactory != null)
                return;

            //setup the normal map configuration
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnduranceGoals.cfg.xml");
            Configuration nhconfig = new Configuration().Configure(configFile);

            //setup the fluent map configuration
            configuration  =Fluently.Configure(nhconfig);

            foreach (Assembly assembly in assemblies)
            {
                configuration.Mappings(m => m.FluentMappings
                                                .AddFromAssembly(assembly)
                                                .Conventions.Add(
                                                    ForeignKey.Format(
                                                        (p, t) => t.Name + "Id")));
            }

            // Use this to recreate a phisical database
            // CreatePhisycalDatabase(configuration);

            sessionFactory = configuration.BuildSessionFactory();

            session = sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var innermsg = ex.InnerException.Message;
                throw;
            }
        }

        private void CreatePhisycalDatabase(FluentConfiguration fluentConfiguration)
        {
            configuration.ExposeConfiguration(
                  c => new SchemaExport(c).Execute(true, true, false))
             .BuildConfiguration();
        }
    }
}