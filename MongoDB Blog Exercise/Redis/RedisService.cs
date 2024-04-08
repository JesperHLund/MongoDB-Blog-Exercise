using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace MongoDB_Blog_Exercise.Redis
{
    public class RedisService
    {

        private readonly string _hostname;
        private readonly int _port;
        private readonly string _password;
        private ConnectionMultiplexer _redisConnection;

        public RedisService(string hostname, int port, string password)
        {
            _hostname = hostname;
            _port = port;
            _password = password;
        }

        public void Connect()
        {
            _redisConnection = ConnectionMultiplexer.Connect($"{_hostname}:{_port},password={_password}");
        }

        public StackExchange.Redis.IDatabase GetDatabase()
        {
            return _redisConnection.GetDatabase();
        }

        //Add post to redis by blog id
        public void AddPostToRedis(Models.Post post)
        {
            var db = GetDatabase();
            db.StringSet($"Post:{post.BlogId}:Title", post.Title);
            db.StringSet($"Post:{post.BlogId}:Content", post.Content);
            db.StringSet($"Post:{post.BlogId}:PostId", post.PostId);
            db.StringSet($"Post:{post.BlogId}:Date", JsonConvert.SerializeObject(post.Date));
        }

        //get all posts from redis by blog id
        public Models.Post GetPostFromRedis(int blogId)
        {
            var db = GetDatabase();
            var title = db.StringGet($"Post:{blogId}:Title");
            var content = db.StringGet($"Post:{blogId}:Content");
            var postId = db.StringGet($"Post:{blogId}:PostId");
            var date = db.StringGet($"Post:{blogId}:Date");

            return new Models.Post(title, content, int.Parse(postId), JsonConvert.DeserializeObject<DateTime>(date));
        }


    }
}
