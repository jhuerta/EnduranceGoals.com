using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class GoalParticipantClassMap : ClassMap<GoalParticipant>
    {
        public GoalParticipantClassMap()
        {
            Table("GoalParticipants");

            Id(c => c.Id);

            Map(gp => gp.SignedOnDate);
            
            References(gp => gp.User)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("UserId");

            References(gp => gp.Goal)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("GoalId");
        }
    }
}
