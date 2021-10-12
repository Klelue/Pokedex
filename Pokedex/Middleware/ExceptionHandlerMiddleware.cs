using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pokedex.Exception;

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
                {typeof(WrongValuesException), HandleWrongValueException}
            };
        }

        private Task HandleWrongValueException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            throw new NotImplementedException();
        }

        private Task HandleWrongTypException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            throw new NotImplementedException();
        }

        private Task HandleTotalOutOfRangeException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;


            throw new NotImplementedException();
        }

        private Task HandleNonUniquePokemonException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;


            throw new NotImplementedException();
        }

        private Task HandleNoIntException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;


            throw new NotImplementedException();
        }

        private Task HandleNoBoolException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;


            throw new NotImplementedException();
        }

        private Task HandleIvalidCsvDataException(HttpContext context, System.Exception exception)
        {
            context = SetContextResponseContentType(context);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;


            throw new NotImplementedException();
        }

        private HttpContext SetContextResponseContentType(HttpContext context)
        {
            context.Response.ContentType = ResponseContentType;
            return context;
        }
    }
}