using FluentNHibernate.Mapping;

namespace EnduranceGoals.Models.NHMaps
{
    public class VenueClassMap : ClassMap<Venue>
    {
        public VenueClassMap()
        {
            Table("Venues");

            Id(v => v.Id);
            Map(v => v.Name);
            Map(v => v.Latitude);
            Map(v => v.Longitude);
            References(v => v.City)
                .Cascade.SaveUpdate(); ;
        }
    }
}
