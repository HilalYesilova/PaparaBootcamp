using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters
{
    public class ExampleResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {//istek sonrası çalışır

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        { //istek (endpointe gelmeden önce) öncesi çalışır
        }

        
    }
}
