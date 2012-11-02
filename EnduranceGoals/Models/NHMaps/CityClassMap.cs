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

            References(c => c.Country)
                .Cascade.SaveUpdate();

            HasMany(c => c.Venues);
        }
    }
}
