using EnduranceGoals.Infrastructure;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    public class TestContext
    {
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            CurrentSessionContext.Bind(SessionProvider.OpenSession());
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            var session = CurrentSessionContext.Unbind(SessionProvider.SessionFactory);

            if (session != null)
            {
                if (session.Transaction != null && session.Transaction.IsActive)
                {
                    session.Transaction.Rollback();
                }
                else
                {
                    session.Flush();
                }
                session.Close();
            }
        }
    }
}