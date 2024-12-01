namespace IdentityWithJwtTestProject.WebApi.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (IOException ioEx)
            {
                _logger.LogError(ioEx, "An I/O error occurred while processing the request.");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("A file system error occurred.");
            }
            catch (NullReferenceException nullEx)
            {
                _logger.LogError(nullEx, "A null reference error occurred.");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("An internal error occurred due to invalid object references.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing the request.");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("An unexpected system error occurred.");
            }
        }
    }
}
