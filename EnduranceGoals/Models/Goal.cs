using System;
using System.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Goal
    {
        public Goal()
        {
            Participants = new List<User>();
        }

        public virtual void AddParticipant(User user)
        {
            Participants.Add(user);
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
        public virtual ICollection<User> Participants { get; protected set; }
    }
}