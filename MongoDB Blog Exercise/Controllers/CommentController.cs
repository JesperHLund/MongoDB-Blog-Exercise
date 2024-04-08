using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using MongoDB_Blog_Exercise.Models;
using MongoDB_Blog_Exercise.Database;

namespace MongoDB_Blog_Exercise.Controllers
{
    public class CommentController : Controller
    {
 
        private Comment _comment;
        //private Database.Database _database;
        private TempDatabase _database;

        public CommentController()
        {
            
        }


        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            //create a new comment
            _database.AddComment(comment);
            return Ok(comment);
        }

        //Get all comments by blog post id
        [HttpGet("{id}")]
        public IActionResult GetCommentsByPostId(int id)
        {
            //get all comments by blog post id
            return Ok(_database.GetCommentsByPostId(id));
        }
    }
}
