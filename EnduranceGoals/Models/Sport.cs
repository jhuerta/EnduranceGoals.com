using System;
using System.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Sport
    {
        public Sport()
        {
            Goals = new List<Goal>();
        }
        public virtual IList<Goal> Goals { get; protected set; }
        public virtual int Id { get; protected set; }
        public virtual String Name { get; set; }
        public virtual void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }
    }
}