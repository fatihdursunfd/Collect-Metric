using System.Collections.Generic;
using App.Metrics;
using CollectMetrics.Metrics;
using CollectMetrics.Model;
using CollectMetrics.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollectMetrics.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo ;
        private readonly IMetrics _metrics ;

        public UserController(IUserRepo userRepo, IMetrics metrics)
        {
            _userRepo = userRepo;
            _metrics = metrics;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserByID(int id)
        {
            return _userRepo.GetUserByID(id);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userRepo.GetUserByID(id);
            if(user is null)
                return BadRequest();

            _userRepo.DeleteUser(user);
            return Ok();
        }

        [HttpPost]
        public ActionResult AddUser(User User)
        {
            User.Name = User.Name.ToUpper();
            User.Surname = User.Surname.ToUpper();

            _userRepo.AddUser(User);

            _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedUserCounter) ;

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id , User User)
        {
            var user = _userRepo.GetUserByID(id);
            if(user is null)
                return BadRequest();

            user.Name = User.Name is null || User.Name == "string" ? user.Name.ToUpper() : User.Name.ToUpper() ;
            user.Surname = User.Surname is null || User.Surname == "string" ? user.Surname.ToUpper() : User.Surname.ToUpper() ;

            _userRepo.SaveChanges();
            return user ;
        }



    }
}