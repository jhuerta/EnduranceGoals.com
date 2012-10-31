using System;

namespace EnduranceGoals.Models
{
    public class UserGoal
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Goal Goal { get; set; }
        public virtual DateTime SignedOnDate { get; set; }
    }
}