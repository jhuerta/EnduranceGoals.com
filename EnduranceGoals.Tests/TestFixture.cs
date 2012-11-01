using EnduranceGoals.Infrastructure;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    public class TestFixture
    {
        protected ISession session;

        [SetUp]
        public void TestFixtureSetup()
        {
            session = SessionProvider.OpenSession();
            CallSessionContext.Bind(SessionProvider.OpenSession());
        }

        [TearDown]
        public void TestFixtureTeardown()
        {
            var session = CallSessionContext.Unbind(SessionProvider.SessionFactory);
            if (session != null)
            {
                if (session.Transaction != null && session.Transaction.IsActive)
                {
                    session.Transaction.Rollback();
                }
                else
                    session.Flush();

                session.Close();
            }
            session.Dispose();
        }
    }
}