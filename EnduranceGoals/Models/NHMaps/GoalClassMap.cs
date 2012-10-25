using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class GoalClassMap : ClassMap<Goal>
    {
        public GoalClassMap()
        {
            Table("Goals");
            Id(g => g.Id);
            Map(g => g.Name);
            Map(g => g.Date);
            Map(g => g.Description);
            Map(g => g.Web);
            Map(g => g.CreatedOn);

            References(g => g.Venue);
            References(g => g.Sport);
            References(g => g.UserCreator);

            HasManyToMany(g => g.Participants)
                .Cascade.All()
                .Table("goalparticipants");
        }
    }

}

