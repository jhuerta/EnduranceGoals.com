using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class CityClassMap : ClassMap<City>
    {
        public CityClassMap()
        {
            Table("Cities");

            Id(c => c.Id);

            Map(c => c.Name);

            References(c => c.Country,"CountryId");

            HasMany(c => c.Venues).Inverse().Cascade.All();
        }
    }
}
