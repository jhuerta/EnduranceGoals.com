using System;
using System.Collections.Generic;
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
}
