using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PaparaApp.API.Extensions;
using PaparaApp.API.Filters;
using PaparaApp.API.Models;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Products.DTOs;
using PaparaApp.API.SOLID.ISP;

namespace PaparaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IFileProvider _fileProvider;
        public ProductsController(IMapper mapper, IFileProvider fileProvider, IProductService productService)
        {
            _fileProvider = fileProvider;

            _productService = productService;
        }

        [Route("SaveFile")]
        [HttpPost]
        public IActionResult SavePicture(IFormFile file)
        {
            var pictureDirectory = _fileProvider.GetDirectoryContents("wwwroot/pictures");
            var picture = pictureDirectory.Where(x => x.Name == "pictures")!.First();
            var path = Path.Combine(picture.PhysicalPath!, file.FileName);

            using var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);

            return Created($"/pictures/{file.FileName}", null);
        }

        [ExampleResourceFilter]
        [HttpGet]
        public IActionResult GetAll()
        {
            ////EXTENSION METHODS USING EX
            //double price = 200;
            //var kdv = price.CalculateTax();

            //var user = new { Name = "Ahmet", Surname = "Yıldız" };


            //user.Name.GetFullName(user.Surname);
            //var fullName = new StringHelper().GetFullName(user.Name, user.Surname);

            return Ok(_productService.GetAll());
        }

        [IPCheckActionFilter]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpGet("page/{page}/size/{size}")]
        public IActionResult GetProductWithPages(int page, int size)
        {
            return Ok(_productService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(ProductAddDtoRequest request)
        {
            var result = _productService.Add(request);
            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(ProductUpdateDtoRequest request)
        {
            _productService.Update(request);
            return NoContent();
        }

        [HttpDelete]
        //[NotFoundActionFilter] const parametre varsa attr olarak kullanamayız onun yerine
        [ServiceFilter<NotFoundActionFilter>] //ekleyip DI container'a da ekliyoruz.
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }

        #region Model Binding

        #region Complex types with query strings

        /// <summary>
        ///     https://localhost:7136/api/Products?request.name=kalem 1&request.price=20
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Add([FromQuery] ProductAddDtoRequest request)
        //{
        //    //complex type => request body
        //    //simple type => request query string
        //    int result = productService.Add(request);
        //    return Created("", result);
        //} 

        #endregion

        #region Simple Types Example

        //[HttpPost]
        //public IActionResult Add(string name, decimal price)
        //{
        //    ProductAddDtoRequest request = new ProductAddDtoRequest
        //    {
        //        Name = name,
        //        Price = price
        //    };
        //    int result = productService.Add(request);
        //    return Created("", result);
        //} 

        #endregion

        #region Simple Types with Header

        //[HttpPost]
        //public IActionResult Add([FromHeader] string name, [FromHeader] decimal price)
        //{
        //    ProductAddDtoRequest request = new ProductAddDtoRequest
        //    {
        //        Name = name,
        //        Price = price
        //    };
        //    int result = productService.Add(request);
        //    return Created("", result);
        //} 

        #endregion

        #region complex type with header
        //header with  only property name
        //[HttpPost]
        //public IActionResult Add([FromHeader] ProductAddDtoRequest request)
        //{
        //    int result = productService.Add(request);
        //    return Created("", result);
        //}
        #endregion

        #region Simple typles with route data
        //[HttpPost("{name}/{price}")] //eğer postun içine maplemiş isek [FromRoute] attr gerek kalmaz. Querystring yerine bu yöntem daha efektiftir.
        //public IActionResult Add(string name, decimal price)
        //{
        //    ProductAddDtoRequest request = new ProductAddDtoRequest
        //    {
        //        Name = name,
        //        Price = price
        //    };
        //    int result = productService.Add(request);
        //    return Created("", result);
        //}

        //[HttpPost("version/{version}/")]
        //public IActionResult Add(ProductAddDtoRequest request)
        //{

        //    int result = productService.Add(request);
        //    return Created("", result);
        //}
        #endregion

        #region Simple types mix
        ///// <summary>
        ///// https://localhost:7250/api/Products/version/v1?type=2
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="version"></param>
        ///// <param name="type"></param>
        ///// <param name="spaType"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Add(ProductAddDtoRequest request, string version, string type, [FromHeader] string spaType)//simple type default olarak bodyden gelir,route'da version tanımladığımız için attr gerek yok, diğer yolladığımız parametreler default querystringten beklenir. Headerdan bir şey beklersen attr tanımlamak zorundayız çünkü Header'ın defaultu yoktur.
        //{

        //    int result = productService.Add(request);
        //    return Created("", result);
        //}
        #endregion
        #endregion

        #region Routing Attr use case
        //[Route("/simple-add/{version}")] //başına / koyarsak direkt /simple-add ile başlar API product girmez
        //[HttpPost]
        //public IActionResult SimpleAdd(ProductAddDtoRequest request, [FromRoute] string version)
        //{
        //    int result = productService.Add(request);
        //    return Created("", result);
        //}
        #endregion

        //[NonAction]
        //public string GetFullName(string name)
        //{
        //    return $"{name}";
        //}
    }
}
