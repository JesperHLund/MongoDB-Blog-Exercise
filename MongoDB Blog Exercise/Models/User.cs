namespace MongoDB_Blog_Exercise.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string ScreenName { get; set; }
        public string username { get; set; }
        public string bio { get; set; }

        public User(string screenName, string username, string bio)
        {
            ScreenName = screenName;
            this.username = username;
            this.bio = bio;
        }
    }
}
