namespace EnduranceGoals.Models
{
    public class GoalParticipant
    {
        public virtual User User { get; set; }
        public virtual Goal Goal { get; set; }
    }
}