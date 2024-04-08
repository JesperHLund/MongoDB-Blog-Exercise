using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MongoDB_Blog_Exercise.Models
{
    public class Comment
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }

        public Comment(string content, int authorId, int postId, DateTime date)
        {
            Content = content;
            AuthorId = authorId;
            PostId = postId;
            Date = date;
        }
    }
}
