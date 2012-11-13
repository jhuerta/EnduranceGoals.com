using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals
{
    public class VenuesToCollectionResolver : ValueResolver<Goal, ICollection<SelectListItem>>
    {
        protected override ICollection<SelectListItem> ResolveCore(Goal goal)
        {
            var venues = new Venues(SessionProvider.CurrentSession)
                .GetAll()
                .Select(m => new SelectListItem
                                 {
                                     Selected = (goal.Venue == null) ? false : (m.Id == goal.Venue.Id),
                                     Text = string.Format("{0}, {1} ({2})", m.Name, m.City, m.City.Country),
                                     Value = m.Id.ToString()
                                 }).ToList();

            return venues;
        }
    }
}