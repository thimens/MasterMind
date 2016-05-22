using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Mastermind.Filters
{
    public class ExceptionStatusFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception.Message);
        }
    }
}
