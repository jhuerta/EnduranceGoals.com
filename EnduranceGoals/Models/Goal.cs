using System;
using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Goal 
    {
        public Goal()
        {
            Participants = new HashedSet<GoalParticipant>();
            Date = DateTime.Now.AddMonths(6);
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
        public virtual bool IsOwner(string username)
        {
            return username == UserCreator.Username;
        }

        public virtual bool IsParticipant(string username)
        {
            return Participants.Any(goalParticipant => goalParticipant.User.Username.Equals(username));
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