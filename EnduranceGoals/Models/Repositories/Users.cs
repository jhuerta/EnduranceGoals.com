using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EnduranceGoals.Models.Repositories
{
    public class Users : RepositoryWithName<User>, IUsersRepository
    {
        public Users(ISession _session)
            : base(_session)
        {
        }

        public User GetByUserName(string userName)
        {
            return session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Username", userName))
                .UniqueResult<User>();
        }

        public ICollection<User> GetAllByGoals(Goal goal)
        {
            return session.CreateCriteria(typeof(User))
                .CreateCriteria("Goals")
                .Add(Expression.Eq("Goal", goal))
                .List<User>();
        }

        public User GetByEmail(string email)
        {
            return session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Email", email))
                .UniqueResult<User>();
        }
    }
}