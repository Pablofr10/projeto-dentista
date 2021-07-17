using System;
using System.Net;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Response;
using Dentista.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Dentista.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AutenticacaoException ex)
            {
                await HandleAutenticacaoExceptionAsync(httpContext, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string mensagem)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErroDetalheResponse
            {
                StatusCode = context.Response.StatusCode,
                Mensagem = mensagem
            }.ToString());
        }

        private Task HandleAutenticacaoExceptionAsync(HttpContext context, string mensagem)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return context.Response.WriteAsync(new ErroDetalheResponse
            {
                StatusCode = context.Response.StatusCode,
                Mensagem = mensagem
            }.ToString());
        }
    }
}
