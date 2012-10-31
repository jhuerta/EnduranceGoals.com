namespace EnduranceGoals.Models.Repositories
{
    public interface IRepositoryWithName<T>
    {
        T GetByName(string entityName);
    }
}