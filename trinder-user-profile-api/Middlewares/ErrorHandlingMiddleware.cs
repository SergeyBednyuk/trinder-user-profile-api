
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Trinder.UserProfile.Domain.Exceptions;

namespace trinder_user_profile_api.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch(NotFoundException ex)
			{
                logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch(AlreadyExistException ex)
            {
                logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (CantBePerformedException ex)
            {
                logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(ex.Message);
            }
            catch(ValidationException ex)
            {
                logger.LogWarning(ex, ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "ValidationFailure",
                    Title = "Validation error",
                    Detail = "One or more validation errors has occurred"
                };

                if (ex.Errors is not null)
                {
                    problemDetails.Extensions["errors"] = ex.Errors;
                }

                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (Exception ex)
			{
                logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
