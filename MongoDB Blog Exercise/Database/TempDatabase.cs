using Microsoft.EntityFrameworkCore;
using MongoDB_Blog_Exercise.Models;

namespace MongoDB_Blog_Exercise.Database
{
    public class TempDatabase: DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        //add a contructor for an inmemory database
        public TempDatabase(DbContextOptions<TempDatabase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Blog>().HasKey(b => b.BlogId);
            modelBuilder.Entity<Blog>().Property(b => b.BlogId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>().HasKey(p => p.PostId);
            modelBuilder.Entity<Post>().Property(p => p.PostId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentId);
            modelBuilder.Entity<Comment>().Property(c => c.CommentId).ValueGeneratedOnAdd();
        }

        //Add user method
        public bool AddUser(User user)
        {
            try { 
                Users.Add(user);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding user");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //update screenname method
        public bool UpdateScreenName(User _user)
        {
            try
            {
                var user = Users.Find(_user.UserId);
                user.ScreenName = _user.ScreenName;
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating screen name");
                Console.WriteLine(e.Message);
                return false;
            }
        }


        //add blog method
        public bool AddBlog(Blog blog)
        {
            try
            {
                Blogs.Add(blog);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding blog");
                Console.WriteLine(e.Message);
                return false;
            }
        }


        //add post method
        public bool AddPost(Post post)
        {
            try
            {
                var _post = post;
                _post.Date = DateTime.Now;
                Posts.Add(_post);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding post");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //get all posts by blog id method
        public List<Post> GetPostsByBlogId(int blogId)
        {
            return Posts.Where(p => p.BlogId == blogId).ToList();
        }

        //update post method
        public bool UpdatePost(Post post)
        {
            try
            {
                var postToUpdate = Posts.Find(post.PostId);
                postToUpdate.Title = post.Title;
                postToUpdate.Content = post.Content;
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating post");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //add comment method
        public bool AddComment(Comment comment)
        {
            try
            {
               var _comment = comment;
                _comment.Date = DateTime.Now;
                Comments.Add(_comment);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding comment");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //get all comments by post id method
        public List<Comment> GetCommentsByPostId(int postId)
        {
            return Comments.Where(c => c.PostId == postId).ToList();
        }

    }
}
