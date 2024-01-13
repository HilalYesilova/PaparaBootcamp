namespace PaparaApp.API.Models.Products
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;

        public List<Product> GetAll() => productRepository.GetAll();

        //burada logic işlemler yapılır. BL kısmında bizim dönüşümler kod oynalamarı yapılabilir.

    }
}
