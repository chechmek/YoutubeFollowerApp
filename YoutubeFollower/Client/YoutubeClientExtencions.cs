namespace YoutubeFollower.Client
{
    public static class YoutubeClientExtencions
    {
        public static IServiceCollection AddYoutubeClient(this IServiceCollection services)
        { 
            services.AddSingleton<IYoutubeClient, YoutubeClient>(); // FakeYoutubeClient if dont have inet rn)
            return services;
        }
    }
}
