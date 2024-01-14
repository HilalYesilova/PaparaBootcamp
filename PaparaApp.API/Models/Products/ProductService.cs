using AutoMapper;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
            productRepository = new ProductRepository();
        }
        public List<ProductDto> GetAll()
        {
            List<Product> products = productRepository.GetAll();
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;

            #region 1. way

            //List<ProductDto> productDtos = new List<ProductDto>();

            //foreach (Product product in products)
            //    productDtos.Add(new ProductDto
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Price = product.Price
            //    });

            // return productDtos; 

            #endregion
        }

        public ResponseDto<int> Add(ProductAddDtoRequest request)
        {
            int id = new Random().Next(1, 1000);


            Product product = new Product
            {
                Id = id,
                Name = request.Name,
                Price = request.Price!.Value
            };

            productRepository.Add(product);
            return ResponseDto<int>.Success(id);
            //return new ResponseDto<int> { Data = id };
        }
        public void Update(ProductUpdateDtoRequest request)
        {
            Product product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };

            productRepository.Update(product);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
