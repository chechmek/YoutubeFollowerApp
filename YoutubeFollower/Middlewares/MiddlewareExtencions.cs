namespace YoutubeFollower.Middlewares
{
    public static class MiddlewareExtencions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeptionHandlerMiddleware>();
        }
    }
}
