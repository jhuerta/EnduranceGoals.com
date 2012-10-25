using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnduranceGoals.Models
{
    public class User
    {
        

        public User()
        {
            Goals = new List<Goal>();
        }

        public virtual void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreatedOn { get; protected set; }
        public virtual IList<Goal> Goals { get; protected set; }
    }
}
