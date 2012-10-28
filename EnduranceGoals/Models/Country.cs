using System;
using System.Collections.Generic;

namespace EnduranceGoals.Models
{
    public class Country
    {
        //public Country()
        //{
        //    Cities = new List<City>();
        //}

        public virtual int Id { get; protected set; }
        public virtual String Name { get; set; }

    }
}