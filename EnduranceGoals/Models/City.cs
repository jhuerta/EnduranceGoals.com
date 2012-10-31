using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class City
    {
        public City()
        {
            Venues = new HashedSet<Venue>();
        }
        public virtual int Id { get; protected set; }
        public virtual String Name { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Venue> Venues { get; protected set; }
        public virtual void AddVenue(Venue venue)
        {
            Venues.Add(venue);
        }
    }
}