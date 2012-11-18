using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EnduranceGoals.Models;
using System.Web.Mvc;

namespace EnduranceGoals
{
    public class ListOfParticipantsResolver : ValueResolver<Goal, IDictionary<int, string>>
    {
        protected override IDictionary<int, string> ResolveCore(Goal goal)
        {
            return goal.Participants.ToDictionary(
                participant => participant.Id, 
                participant => participant.User.Username);
        }
    }
}