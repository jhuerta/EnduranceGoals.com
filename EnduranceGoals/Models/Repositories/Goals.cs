using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EnduranceGoals.Models.Repositories
{
    public class Goals : RepositoryWithName<Goal>, IGoalsRepository
    {
        public Goals(ISession _session)
            : base(_session)
        {
        }

        public IList<Goal> GetAllBySport(Sport sport)
        {
            return session.CreateCriteria<Goal>()
                .Add(Restrictions.Eq("Sport", sport)).List<Goal>();
        }

        public IList<Goal> GetAllByUserCreator(User user)
        {

            return session.CreateCriteria<Goal>()
                .Add(Restrictions.Eq("UserCreator", user)).List<Goal>();
        }

        public IList<Goal> GetAllByVenue(Venue venue)
        {
            return session.CreateCriteria<Goal>()
                .Add(Restrictions.Eq("Venue", venue)).List<Goal>();
        }

        public IList<Goal> GetAllByParticipant(User participant)
        {
            return session.CreateCriteria(typeof (Goal))
                .CreateCriteria("Participants")
                .Add(Expression.Eq("User", participant))
                .List<Goal>();
        }

        public IList<Goal> GetAllByCreator(User creator)
        {
            return session.CreateCriteria(typeof(Goal))
                .CreateCriteria("UserCreator")
                .Add(Expression.Eq("Id", creator.Id))
                .List<Goal>();
        }

        public IList<Goal> FindUpcomingGoals()
        {
            return session.CreateCriteria(typeof (Goal))
                .Add(Expression.Gt("Date", DateTime.Now))
                .List<Goal>();
        }
    }
}