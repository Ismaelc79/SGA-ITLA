using System.Net;
using System.Text.Json;
using AppException = SGA.Application.Exceptions.ApplicationException;
using SGA.Application.Exceptions;

namespace SGA.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var metodo = context.Request.Method;
            var ruta = context.Request.Path;

            _logger.LogInformation("Accion recibida: {Metodo} {Ruta}", metodo, ruta);

            try
            {
                await _next(context);

                _logger.LogInformation(
                    "Accion completada: {Metodo} {Ruta} -> {StatusCode}",
                    metodo, ruta, context.Response.StatusCode);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Recurso no encontrado: {Metodo} {Ruta}", metodo, ruta);
                await EscribirRespuestaAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (BusinessRuleException ex)
            {
                _logger.LogWarning(ex, "Regla de negocio violada: {Metodo} {Ruta}", metodo, ruta);
                await EscribirRespuestaAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "Excepcion de aplicacion: {Metodo} {Ruta}", metodo, ruta);
                await EscribirRespuestaAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado: {Metodo} {Ruta}", metodo, ruta);
                await EscribirRespuestaAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "Ocurrio un error inesperado en el servidor.");
            }
        }

        private static async Task EscribirRespuestaAsync(HttpContext context, HttpStatusCode statusCode, string mensaje)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var respuesta = new
            {
                success = false,
                message = mensaje,
                data = (object?)null,
                errors = new List<string> { mensaje }
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(respuesta));
        }
    }
}