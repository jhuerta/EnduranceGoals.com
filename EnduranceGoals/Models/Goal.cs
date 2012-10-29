using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Iesi.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Goal
    {
        public Goal()
        {
            UserGoals = new HashedSet<UserGoal>();
        }

        public virtual void AddParticipant(User user, DateTime signedOndate)
        {
            this.UserGoals.Add(
                new UserGoal
                    {
                        User = user,
                        Goal = this,
                        SignedOnDate = signedOndate
                    });
        }

        public virtual int Id { get; protected set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual User UserCreator { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Web { get; set; }
        public virtual ICollection<UserGoal> UserGoals { get; protected set; }
    }
}