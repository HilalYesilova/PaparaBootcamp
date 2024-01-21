using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Filters
{
    public class NotFoundActionFilter(IProductRepository repository) : Attribute, IActionFilter
    {
        private readonly IProductRepository _productRepository = repository;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //metota girmeden önce


            //Clean Code
            //Fast Fail
            //Guard Clause 
            //bu yaklaşım iç içe if blokları yazmaktan ve else yazmaktan kurtarır 

            var idAsObject = context.ActionArguments.FirstOrDefault(s => s.Key == "id");
            //var idAsObject = context.ActionArguments["id"]; //parametrelerden id olanı

            //if (idAsObject is not null)
            //{
                //var id =
                //var hasProduct = _productRepository.GetById(id);
            //}


            //fast fail ilk olumsuz durumları check et başarılı en sonda olsun. Performansa etkisi olmaz okunabilirlik ve clean code açısından daha best practice'dir.
            if (idAsObject.Key is null || idAsObject.Value is null) return;
            if (!int.TryParse(idAsObject.Value.ToString(), out var id)) return;
            var hasProduct = _productRepository.GetById(id);
            if (hasProduct is null) context.Result = new NotFoundObjectResult($"Product not found with id: {id}");

        }
    }
}
