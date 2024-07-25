using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIPro.Filters
{
    public class MyActionFiltersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Write Any Logics
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Write Any Logics
            base.OnActionExecuted(context);
        }
    }
}
