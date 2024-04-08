namespace MongoDB_Blog_Exercise.Redis
{
    public class RedisServiceFactory
    {
        public static RedisService Create()
        {
            return new RedisService(
                "redis",
                6379,
                ""
            );
        }
    }
}
