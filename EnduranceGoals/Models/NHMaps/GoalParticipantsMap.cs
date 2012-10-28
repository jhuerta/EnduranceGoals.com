using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class GoalParticipantsMap : ClassMap<GoalParticipant>
    {
        public GoalParticipantsMap()
        {
            Table("GoalParticipants");

            Id(c => c.Id);
            Map(gp => gp.SignedOnDate);

            References(gp => gp.User)
                .Not.Nullable()
                .Column("UserId");

            References(gp => gp.Goal)
                .Not.Nullable()
                .Column("GoalId");
        }
    }
}
