namespace MongoDB_Blog_Exercise.Models
{
    public class Blog
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int BlogId { get; set; }

        public Blog(string title, string content, int authorId)
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
        }

    }
}
