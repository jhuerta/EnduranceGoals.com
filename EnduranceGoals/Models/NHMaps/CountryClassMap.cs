using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class CountryClassMap : ClassMap<Country>
    {
        public CountryClassMap()
        {
            Table("Countries");

            Id(c => c.Id);

            Map(c => c.Name);

            HasMany(c => c.Cities).Inverse().Cascade.All();
        }
    }
}
