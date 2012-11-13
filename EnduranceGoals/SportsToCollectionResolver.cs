using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals
{
    public class SportsToCollectionResolver : ValueResolver<Goal, ICollection<SelectListItem>>
    {
        protected override ICollection<SelectListItem> ResolveCore(Goal goal)
        {
            var sports = new Sports(SessionProvider.CurrentSession)
                .GetAll()
                .Select(m => new SelectListItem
                {
                    Selected = goal.Sport == null ? false : (m.Id == goal.Sport.Id),
                    Text = m.Name,
                    Value = m.Id.ToString()
                }).ToList();

            return sports;
        }
    }
}