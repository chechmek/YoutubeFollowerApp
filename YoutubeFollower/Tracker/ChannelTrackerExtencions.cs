namespace YoutubeFollower.Tracker
{
    public static class ChannelTrackerExtencions
    {
        public static IServiceCollection AddChannelTracker(this IServiceCollection services)
        {
            //new ChannelTracker();

           // services.AddSingleton<IChannelTracker, ChannelTracker>();

            return services;
        }
    }
}
