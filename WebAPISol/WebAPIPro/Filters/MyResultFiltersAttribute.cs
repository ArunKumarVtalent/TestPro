using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIPro.Filters
{
    public class MyResultFiltersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Write any logics
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Write any logics
            base.OnResultExecuted(context);
        }
    }
}
