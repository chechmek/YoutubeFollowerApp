namespace YoutubeFollower.Repository
{
    public static class RepositoryExtencions
    {
        public static IServiceCollection AddFollowerRepository(this IServiceCollection services)
        {
            services.AddTransient<IFollowerRepository, FollowerRepository>();
            return services;
        }
    }
}
