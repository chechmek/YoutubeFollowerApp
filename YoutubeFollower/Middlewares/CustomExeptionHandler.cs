using System.Net;
using System.Text.Json;
using YoutubeFollower.Exceptions;

namespace YoutubeFollower.Middlewares
{
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExeptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptions(context, ex);
            }
        }
        private  Task HandleExceptions(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = "Internal server error";
            switch (ex)
            {
                case ChannelNotExistsException channelNotExists:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize("There are no channel with this ID!");
                    break;
                case NoChannelsException noChannelsException:
                    code = HttpStatusCode.NoContent;
                    result = JsonSerializer.Serialize("No channels!");
                    break;
                case ChannelAlreadyExistsException noChannelsException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize("Channel already exists!");
                    break;
                case NullReferenceException nullReference:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(nullReference.Message);
                    break;
                case Exception exc:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(exc.Message);
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
