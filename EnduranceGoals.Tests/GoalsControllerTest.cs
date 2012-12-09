using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EnduranceGoals.Controllers;
using EnduranceGoals.Infrastructure;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;
using System.Web;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    class GoalsControllerTest
    {
        [Test]
        public void RaceList_returns_json_object()
        {
            //ISession session;

            //NHibernateProfiler.Initialize();

            var wholisticSession = SessionProvider.OpenSession();

            CurrentSessionContext.Bind(wholisticSession);

            //session = SessionProvider.CurrentSession;

            // Arrange
            var goalsController = new GoalsController();

            // Act
            var actual = goalsController.RaceList(0);

            // Assert
            Assert.IsInstanceOf<JsonResult>(actual);
        }

        [Test]
        public void RaceList_returns_result_is_not_null()
        {
            // Arrange
            var goalsController = new GoalsController();

            // Act
            var actual = (JsonResult) goalsController.RaceList(0);

            // Assert
            Assert.IsNotNull(actual);
            var data = actual.Data;
            Assert.IsNotNull(data);
        }

        [Test]
        public void RaceList_returns_result_in_Goals_variable()
        {
            // Arrange
            var goalsController = new GoalsController();

            // Act
            var actual = (JsonResult)goalsController.RaceList(0);

            // Assert
            var data = actual.Data;
            var type = data.GetType();
            var goalsProperty = type.GetProperty("Goals");
            var goalsValue = goalsProperty.GetValue(data, null);
 
            Assert.NotNull(goalsValue);
        }

    }
}
