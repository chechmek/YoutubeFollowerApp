namespace YoutubeFollower.Json
{
    public static class JsonExtencions
    {
        public static IServiceCollection AddJsonConverter(this IServiceCollection services)
        {
            services.AddTransient<IJsonConverter, JsonConverter>();
            return services;
        }
    }
}
