using Microsoft.AspNetCore.Http;
using Pokedex.Exception;
using Pokedex.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private const string ResponseContentType = "application/problem+json";

        private readonly RequestDelegate next;
        private readonly IDictionary exceptionDictionary;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;

            exceptionDictionary = new Dictionary<Type, Func<HttpContext, System.Exception, Task>>()
            {
                {typeof(InvalidCsvDataException), HandleIvalidCsvDataException},
                {typeof(NoBoolException), HandleNoBoolException},
                {typeof(NoIntException), HandleNoIntException},
                {typeof(NonUniquePokemonException), HandleNonUniquePokemonException},
                {typeof(TotalOutOfRangeException), HandleTotalOutOfRangeException},
                {typeof(WrongTypException), HandleWrongTypException},
                {typeof(WrongValuesException), HandleWrongValueException},
                {typeof(PokemonNotFoundException), HandlePokemonNotFoundException},
                {typeof(DexNumberOutOfRangeException), HandleDexNumberOutOfRangeExcpetion},
                {typeof(PokemonNotImportedException), HandlePokemonNotImportedException}
            };
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