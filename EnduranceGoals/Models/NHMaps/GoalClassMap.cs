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
            Map(g => g.Web, "EventWeb");
            Map(g => g.CreatedOn);

            References(g => g.Venue)
                .Cascade.SaveUpdate(); ;
            References(g => g.Sport)
                .Cascade.SaveUpdate(); ;
            References(g => g.UserCreator, "UserCreatorId")
                .Cascade.SaveUpdate(); ;

            HasMany(g => g.Participants)
                .Table("GoalParticipants")
                .Cascade.AllDeleteOrphan()
                .KeyColumn("GoalId")
                .Inverse();
        }
    }

}

