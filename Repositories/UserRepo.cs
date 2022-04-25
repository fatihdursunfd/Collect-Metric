using System.Collections.Generic;
using System.Linq;
using App.Metrics;
using CollectMetrics.Contexts;
using CollectMetrics.Metrics;
using CollectMetrics.Model;

namespace CollectMetrics.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _userContext;

        private readonly IMetrics _metrics;

        public UserRepo(UserContext userContext, IMetrics metrics)
        {

            _userContext = userContext;
            _metrics = metrics;

            _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedDbConnectionCounter);
        }

        public void AddUser(User User)
        {
            _userContext.User.Add(User);
            SaveChanges();
        }

        public void DeleteUser(User User)
        {
            _userContext.Remove(User);
            SaveChanges();
        }

        public User GetUserByID(int id)
        {
            return _userContext.User.Where(x => x.ID == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return _userContext.User.ToList();
        }

        public void SaveChanges()
        {
            _userContext.SaveChanges();
        }

    }
}