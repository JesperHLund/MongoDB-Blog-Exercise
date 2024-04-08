using Microsoft.AspNetCore.Mvc;
using MongoDB_Blog_Exercise.Models;
using MongoDB_Blog_Exercise.Database;

namespace MongoDB_Blog_Exercise.Controllers
{
    public class PostsController : Controller
    {

        private Post _post;
        //private Database.Database _database;
        private TempDatabase _database;
        public PostsController() 
        {
            
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] Post post)
        {
            //create a new post
            if(_database.AddPost(post))
            {
                return Ok(post);
            }
            else
            {
                return BadRequest("Creating post failed");
            }

        }

        [HttpPost]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            //update the post
            if(_database.UpdatePost(post))
            {
                return Ok(post);
            }
            else
            {
                return BadRequest("Updating post failed");
            }
        }

        //Get all posts by blog id
        [HttpGet("{id}")]
        public IActionResult GetPostsByBlogId(int id)
        {
            //get all posts by blog id
            return Ok(_database.GetPostsByBlogId(id));
        }


    }
}
