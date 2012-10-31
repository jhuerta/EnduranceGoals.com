using System.Collections.Generic;

namespace EnduranceGoals.Models.Repositories
{
    public interface IUsersRepository
    {
        User GetByUserName(string userName);
        ICollection<User> GetAllByGoals(Goal goal);
    }
}