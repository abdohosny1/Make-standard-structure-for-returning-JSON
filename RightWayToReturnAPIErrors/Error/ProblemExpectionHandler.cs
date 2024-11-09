using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RightWayToReturnAPIErrors.Error
{

    [Serializable]
    public class ProblemExpection :Exception
    {
        public string Error { get; set; }
        public string Message { get; set; }

        public ProblemExpection(string message, string error)
        {
            Message = message;
            Error = error;
        }
    }

    public class ProblemExpectionHandler : IExceptionHandler
    {

        private readonly IProblemDetailsService _problemDetailsService;

        public ProblemExpectionHandler(IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
          if(exception is not ProblemExpection problemEx)
            {
                return true;
            }

            var problemDetails = new ProblemDetails
            {
                Detail= problemEx.Message,
                Status=StatusCodes.Status400BadRequest,
                Title=problemEx.Error,
                Type="Bad Request"
            };

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext=httpContext,
                ProblemDetails= problemDetails
            });
        }
    }
}
