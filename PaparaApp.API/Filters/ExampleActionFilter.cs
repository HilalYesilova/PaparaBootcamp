using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters
{
    public class ExampleActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {//metot(endpointin içine girmeden) çalıştıktan sonra
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {//metot çalışmadan önce
            throw new NotImplementedException();
        }
    }
}
