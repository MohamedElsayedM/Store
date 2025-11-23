using Store.G05.Domain.Exceptions;
using Store.G05.Shared.ErrorModels;

namespace Store.G05.web.Middlewares
{
    public class GlobleErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobleErrorHandlingMiddleware> _logger;

        public GlobleErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobleErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public  async Task InvokeAsync(HttpContext context)
        {
            try
            {
              await  _next.Invoke(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    await HandlingNotFoundEndpointAsync(context);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandlingErrorAsync(context, ex);

            }
        }

        private static async Task HandlingErrorAsync(HttpContext context, Exception ex)
        {
            //set the status code
            //set the content-type
            // set the responce object( body)
            //return the responce

            context.Response.ContentType = "application/json";
            var responce = new ErrorDetails()
            {
                ErrorMessage = ex.Message
            };

            responce.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = responce.StatusCode;

            await context.Response.WriteAsJsonAsync(responce);
        }

        private static async Task HandlingNotFoundEndpointAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var responce = new ErrorDetails()
            {
                StatusCode = StatusCodes.Status404NotFound,
                ErrorMessage = $"Endpoint {context.Request.Path} NotFound !"
            };
            await context.Response.WriteAsJsonAsync(responce);
        }
    }
}
