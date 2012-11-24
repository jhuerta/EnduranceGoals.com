namespace EnduranceGoals.Models.ViewModels
{
    public class MembershipManagementViewModel
    {
        public MembershipManagementViewModel(bool isSubscribed, int goalId)
        {
            IsSubscribed = isSubscribed;
            GoalId = goalId;
        }

        public bool IsSubscribed { get; private set; }
        public int GoalId { get; private set; }
        public string DivId
        {
            get { return "SubscriptionStatus-" + GoalId; }
        }
    }
}