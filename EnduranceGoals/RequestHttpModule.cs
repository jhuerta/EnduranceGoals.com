using System;
using System.Web;
using EnduranceGoals.Infrastructure;
using NHibernate;
using NHibernate.Context;

namespace EnduranceGoals
{
    public class RequestHttpModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        public void context_BeginRequest(Object sender, EventArgs e)
        {
            ManagedWebSessionContext.Bind(HttpContext.Current, SessionProvider.OpenSession());
        }

        public void context_EndRequest(Object sender, EventArgs e)
        {
            ISession session = ManagedWebSessionContext.Unbind(
                HttpContext.Current, SessionProvider.SessionFactory);

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
        }
    }
}