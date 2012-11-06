using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals
{
    public class VenueToCollectionResolver : ValueResolver<Goal, SelectList>
    {
        protected override SelectList ResolveCore(Goal goal)
        {
            var venues = new Venues(SessionProvider.CurrentSession).GetAll();

            var query = venues.Select(v => new SelectListItem()
                                               {
                                                   Text = v.Id.ToString(),
                                                   Value = string.Format("{0}, {1} ({2})", v.Name, v.City, v.City.Country)
                                               });

            return new SelectList(query, "Text", "Value");
        }
    }
}