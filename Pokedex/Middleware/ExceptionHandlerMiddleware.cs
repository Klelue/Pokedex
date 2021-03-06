using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pokedex.Abstractions.Exception;
using Pokedex.Api.Models;

namespace Pokedex.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private const string ResponseContentType = "application/problem+json";

        private readonly RequestDelegate next;
        private readonly IDictionary<System.Type, Func<HttpContext, System.Exception, Task>> exceptionHandlers;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;

            exceptionHandlers = new Dictionary<System.Type, Func<HttpContext, System.Exception, Task>>
            {
                {typeof(InvalidCsvDataException), HandleIvalidCsvDataException},
                {typeof(NoBoolException), HandleNoBoolException},
                {typeof(NoIntException), HandleNoIntException},
                {typeof(NonUniquePokemonException), HandleNonUniquePokemonException},
                {typeof(TotalOutOfRangeException), HandleTotalOutOfRangeException},
                {typeof(WrongTypeException), HandleWrongTypException},
                {typeof(WrongValuesException), HandleWrongValueException},
                {typeof(PokemonNotFoundException), HandlePokemonNotFoundException},
                {typeof(DexNumberOutOfRangeException), HandleDexNumberOutOfRangeExcpetion},
                {typeof(PokemonNotImportedException), HandlePokemonNotImportedException}
            };
        }

        public async Task Invoke(
            HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (System.Exception exception)
            {
                await this.HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            System.Type type = exception.GetType();
            if (exceptionHandlers.ContainsKey(type))
            {
                return exceptionHandlers[type].Invoke(context, exception);
            }

            return HandleUnknownException(context, exception);
        }

        private Task HandleUnknownException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandlePokemonNotImportedException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status404NotFound;
            return SetContextResponseContentType(context, exception, statusCode);

        }

        private Task HandleDexNumberOutOfRangeExcpetion(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandlePokemonNotFoundException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleWrongValueException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleWrongTypException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleTotalOutOfRangeException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleNonUniquePokemonException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleNoIntException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleNoBoolException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task HandleIvalidCsvDataException(HttpContext context, System.Exception exception)
        {
            int statusCode = StatusCodes.Status400BadRequest;
            return SetContextResponseContentType(context, exception, statusCode);
        }

        private Task SetContextResponseContentType(HttpContext context, System.Exception exception, int statusCode)
        {
            context.Response.ContentType = ResponseContentType;
            context.Response.StatusCode = statusCode;
            ErrorResponse details = new ErrorResponse { code = (int)statusCode, message = exception.Message };

            return context.Response.WriteAsync(SerializeObject(details));
        }

        private static string SerializeObject(ErrorResponse errorResponse)
        {
            return JsonSerializer.Serialize(errorResponse);
        }
    }
}