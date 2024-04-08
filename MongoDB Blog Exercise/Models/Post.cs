using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoDB_Blog_Exercise.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public DateTime Date { get; set; }

        public Post(string title, string content, int blogId, DateTime date)
        {
            Title = title;
            Content = content;
            BlogId = blogId;
            Date = date;
        }
    }
}
