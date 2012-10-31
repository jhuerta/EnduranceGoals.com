using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new HashedSet<City>();
        }

        public virtual ICollection<City> Cities{ get; protected set; }
        public virtual int Id { get; protected set; }
        public virtual String Name { get; set; }

    }
}