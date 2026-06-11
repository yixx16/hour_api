using System.Net;

namespace Horas.Application.Middleware
{


    public class ExceptionHandlerMiddleWare
    {
        private readonly ILogger<ExceptionHandlerMiddleWare> _logger;
        private readonly RequestDelegate _next;


        public ExceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try { await _next(context); }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error ejecutando {Path}", context.Request.Path.Value);
                var (status, message) = exception switch
                {
                    ArgumentException => (HttpStatusCode.NotFound, exception.Message),
                    _ =>  (HttpStatusCode.InternalServerError, "Error interno del servidor")
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)status;
                await context.Response.WriteAsJsonAsync(new {error = message});
            }
        }


    }
}