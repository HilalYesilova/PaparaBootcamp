using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Controllers
{
    /// <summary>
    /// https://localhost:7250/api/products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService ProductService = new ProductService(new ProductRepository());

        [HttpGet]
        public IActionResult GetAll()
        {
            //return "all products";
            //return new OkObjectResult("All products");
            //object to Json Serialization
            //return Ok(new List<Product>()
            //{
            //    new(){Id=1,Name="Product 1",Price=10},
            //    new(){Id=2,Name="Product 2",Price=20},
            //});

            return Ok(ProductService.GetAll());
        }
        [HttpPost]
        public IActionResult Add()
        {
            //return new CreatedResult("",10);
            return Created("", new Product() { Id = 1, Name = "Product 3", Price = 2 });
        }

        [HttpPut]
        public IActionResult Update()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }



        //[NonAction]
        //public string GetFullName(string name)
        //{
        //    return $"{name}";
        //}
    }
}
