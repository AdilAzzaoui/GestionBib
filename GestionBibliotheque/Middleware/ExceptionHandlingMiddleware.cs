using System;
using System.Net;
using System.Text.Json;
using GestionBibliotheque.Exceptions;


namespace GestionBibliotheque.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        // Mapping des exceptions aux codes HTTP
        private static readonly Dictionary<Type, HttpStatusCode> ExceptionStatusMap = new()
        {
            { typeof(BookNotFoundException), HttpStatusCode.NotFound },
            { typeof(DuplicateISBNException), HttpStatusCode.BadRequest },
            { typeof(InvalidIdException), HttpStatusCode.BadRequest }
        };

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Passer au middleware suivant
                await _next(context);
            }
            catch (Exception ex)
            {
                // Gérer l'exception
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Obtenir le code de statut correspondant à l'exception
            var statusCode = ExceptionStatusMap.TryGetValue(exception.GetType(), out var code)
                ? code
                : HttpStatusCode.InternalServerError;

            // Journaliser l'exception
            _logger.LogError(exception, "Une exception a été interceptée.");

            // Préparer le message d'erreur
            var response = new
            {
                statusCode = (int)statusCode,
                message = exception.Message ?? "Une erreur interne s'est produite."
            };

            // Configurer la réponse HTTP
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            // Retourner la réponse JSON
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
