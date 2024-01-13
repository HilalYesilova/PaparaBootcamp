namespace PaparaApp.API.Models.Products
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(int Id);
    }
}
