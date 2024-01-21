using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters
{
    public class ExampleResultFilter : Attribute, IResultFilter
    {//Result için filtreleme ,Microsoft olabaildiğince response'a dokunmama taraftarı
        //Response işlemlerini endpoininde yap
        public void OnResultExecuted(ResultExecutedContext context)
        {//çıktı üretildikten sonra
            
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {//çıktı üretmeden önce
            context.HttpContext.Response.Headers.Append("Content-Type", "application/json");
            //throw new NotImplementedException();
        }
    }
}
