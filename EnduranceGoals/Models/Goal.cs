using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Goal 
    {
        public Goal()
        {
            Participants = new HashedSet<GoalParticipant>();
        }

        public virtual void AddParticipant(User user, DateTime signedOndate)
        {
            Participants.Add(
                new GoalParticipant
                    {
                        User = user,
                        Goal = this,
                        SignedOnDate = signedOndate
                    });
        }

        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual User UserCreator { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Web { get; set; }
        public virtual ICollection<GoalParticipant> Participants { get; protected set; }
    }
}