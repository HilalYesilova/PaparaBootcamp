using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
