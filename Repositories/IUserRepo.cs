using System.Collections.Generic;
using CollectMetrics.Model;

namespace CollectMetrics.Repositories
{
    public interface IUserRepo
    {
        List<User> GetUsers();

        User GetUserByID(int id);

        void AddUser(User User);

        void DeleteUser(User User);

        void SaveChanges();
    }
}