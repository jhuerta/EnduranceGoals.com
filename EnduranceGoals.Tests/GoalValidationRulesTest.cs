using System;
using System.Linq;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.ViewModels;
using NUnit.Framework;
using GoalViewModel = EnduranceGoals.Models.ViewModels.GoalViewModel;

namespace EnduranceGoals.Tests
{

    [TestFixture]
    public class GoalValidationRulesTest
    {
        [TestCase("1,1,1900")]
        [TestCase("1,1,2100")]
        public void DateShouldBeWithinRange(string dateOfGoal)
        {
            SessionProvider.OpenSession();

            var model = new GoalViewModel()
                            {
                                Name = "any",
                                SportId = 0.ToString(),
                                Web = "www.anyweb.com",
                                Date = Convert.ToDateTime(dateOfGoal)
                            };

            var modelStateDictionary = new ModelValidator().ValidateModel(model);

            Assert.That(modelStateDictionary.IsValid, Is.False);
        }

        [Test]
        public void SportIsRequired()
        {
            SessionProvider.OpenSession();
            var model = new GoalViewModel()
            {
                Description = "any",
                Name = "any",
                SportId = null,
                Web = "www.anyweb.com",
                Date = Convert.ToDateTime("1/1/2013")
            };

            var modelStateDictionary = new ModelValidator().ValidateModel(model);

            Assert.That(modelStateDictionary.IsValid, Is.False);
            Assert.That(modelStateDictionary.Values.First().Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void NameIsRequired()
        {
            SessionProvider.OpenSession();
            var model = new GoalViewModel()
            {
                Description = "any",
                Name = null,
                SportId = 0.ToString(),
                Web = "www.anyweb.com",
                Date = Convert.ToDateTime("1/1/2013")
            };

            var modelStateDictionary = new ModelValidator().ValidateModel(model);

            Assert.That(modelStateDictionary.IsValid, Is.False);
            Assert.That(modelStateDictionary.Values.First().Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void WebStringShouldBeLessThan25characters()
        {
            SessionProvider.OpenSession();
            var model = new GoalViewModel()
            {
                Description = "any",
                Name = "any",
                SportId = 0.ToString(),
                Web = "123456789012345678901234567890",
                Date = Convert.ToDateTime("1/1/2013")
            };

            var modelStateDictionary = new ModelValidator().ValidateModel(model);

            Assert.That(modelStateDictionary.IsValid, Is.False);
            Assert.That(modelStateDictionary.Values.First().Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void DescriptionIsRequired()
        {
            SessionProvider.OpenSession();
            var model = new GoalViewModel()
            {
                Name = "any",
                SportId = 0.ToString(),
                Web = "123456789012345678901234567890",
                Date = Convert.ToDateTime("1/1/2013")
            };

            var modelStateDictionary = new ModelValidator().ValidateModel(model);

            Assert.That(modelStateDictionary.IsValid, Is.False);
            Assert.That(modelStateDictionary.Values.First().Errors.Count, Is.EqualTo(1));
        }

        [Test]
        public void WebStringIsRequired()
        {
            SessionProvider.OpenSession();
            var model = new GoalViewModel()
            {
                Description = "any",
                Name = "any",
                SportId = 0.ToString(),
                Web = null,
                Date = Convert.ToDateTime("1/1/2013")
            };

            var modelStateDictionary = new ModelValidator().ValidateModel(model);

            Assert.That(modelStateDictionary.IsValid, Is.False);
            Assert.That(modelStateDictionary.Values.First().Errors.Count, Is.EqualTo(1));
        }
    }
}
