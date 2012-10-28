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
            Table("Sports");
            Id(c => c.Id);
            Map(c => c.Name);
        }
    }
}
