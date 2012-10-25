using System;
using System.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Venue
    {
        public Venue()
        {
            Goals = new List<Goal>();
        }
        public virtual void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }
        public virtual int Id { get; protected set; }
        public virtual Double Longitude { get; set; }
        public virtual Double Latitude { get; set; }
        public virtual String Name { get; set; }
        public virtual City City { get; set; }
        public virtual IList<Goal> Goals { get; protected set; }
    }
}