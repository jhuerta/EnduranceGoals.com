using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals
{
    public class SportsToCollectionResolver : ValueResolver<Goal, SelectList>
    {
        protected override SelectList ResolveCore(Goal sport)
        {
            var sports = new Sports(SessionProvider.CurrentSession).GetAll();
            
            var query = sports.Select(v => new SelectListItem()
                                               {
                                                   Text = v.Id.ToString(),
                                                   Value = v.Name
                                               });

            return new SelectList(query, "Text", "Value");
        }
    }
}