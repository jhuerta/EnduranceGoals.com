using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Iesi.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class User
    {
        

        public User()
        {
            UserGoals = new HashedSet<UserGoal>();
        }

        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual ICollection<UserGoal> UserGoals { get; protected set; }

        public virtual void AddGoal(Goal goal, DateTime signedOndate)
        {
            this.UserGoals.Add(
                new UserGoal
                    {
                        User = this,
                        Goal = goal,
                        SignedOnDate = signedOndate
                    });
        }
    }
}
