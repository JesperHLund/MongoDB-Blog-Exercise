using Microsoft.AspNetCore.Mvc;
using MongoDB_Blog_Exercise.Database;
using MongoDB_Blog_Exercise.Models;

namespace MongoDB_Blog_Exercise.Controllers
{
    public class UserController : Controller
    {

        private User _user;
        //private Database.Database _database;
        private TempDatabase _database;
        public UserController() 
        { 
            
        }

        //httppost to create user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            //create a new user
            if (_database.AddUser(user))
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Creating user failed");
            }
        }

        [HttpPost]
        public IActionResult UpdateScreenName([FromBody] User user)
        {
            //update the user
            if (_database.UpdateScreenName(user))
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Updating user failed");
            }
        }
    }
}
