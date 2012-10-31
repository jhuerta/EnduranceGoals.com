using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class UserClassMap : ClassMap<User>
    {
        public UserClassMap()
        {
            Table("Users");

            Id(u => u.Id);
            Map(u => u.Name);
            Map(u => u.Lastname);
            Map(u => u.Email);
            Map(u => u.Password);
            Map(u => u.Username);
            Map(u => u.CreatedOn);

            HasMany(u => u.Goals)
                .Table("GoalParticipants")
                .Cascade.SaveUpdate()
                .KeyColumn("UserId")
                .Inverse();

            //HasManyToMany(x => x.GoalParticipants)
            //    .Table("GoalParticipants")
            //    .Cascade.SaveUpdate()
            //    .ParentKeyColumn("GoalId")
            //    .ChildKeyColumn("UserId");

            //.LazyLoad()
            //.Cascade.SaveUpdate();
            //.Inverse()
            //.Cascade.SaveUpdate();

        }
    }
}
