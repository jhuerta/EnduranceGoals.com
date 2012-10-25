using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class SportClassMap : ClassMap<Sport>
    {
        public SportClassMap()
        {
            Table("Map");

            Id(c => c.Id);

            Map(c => c.Name);

            HasMany(c => c.Goals).Inverse().Cascade.All();
        }
    }
}
