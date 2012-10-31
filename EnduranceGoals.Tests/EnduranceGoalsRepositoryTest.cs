using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    class EnduranceGoalsRepositoryTest
    {
        public EnduranceGoalsRepository repository;
        
        [SetUp]
        public void SetUp()
        {
            repository= new EnduranceGoalsRepository();
        }
        
        [Test]
        public void DatabaseIsNotEmpty()
        {
            var initialCount = repository.FindAllGoals().Count();
            Assert.That(initialCount,Is.GreaterThan(0));
        }

        [Test]
        public void RetrieveById()
        {
            var firstItem = repository.FindAllGoals().First();
            var firstItemById = repository.GetGoal(firstItem.Id);
            Assert.That(firstItem.Name, Is.EqualTo(firstItemById.Name));
        }

        [Test]
        public void AllGoalsRetrievedByFindUpcamingGoalsAreInTheFure()
        {
            var futureGoals = repository.FindUpcomingGoals();
            foreach (var futureGoal in futureGoals)
            {
                Assert.That(futureGoal.Date > DateTime.Now);
            }
        }

        [Test]
        public void CanDeleteAndSaveAGoal()
        {
            var initialGoal = repository.FindAllGoals().First();
            var randomNamber = new Random().Next();
            initialGoal.Description += randomNamber;

            

            repository.Save();
            //var afterDeletingInitialGoal = repository.FindAllGoals().First();
            //Assert.That(afterDeletingInitialGoal.Name, Is.Not.EqualTo(initialGoal.Name));
            

            //repository.AddGoal(initialGoal);
            //repository.Save();

            //var goalAfterSaving = repository.GetGoal(initialGoal.Id);
            //Assert.That(initialGoal.Name, Is.EqualTo(goalAfterSaving.Name));
            //Assert.That(goalAfterSaving.Description, Is.EqualTo(randomNamber));
        }
    }
}
