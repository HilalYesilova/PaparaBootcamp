namespace PaparaApp.API.Models.Products
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new();

        public ProductRepository()
        {
            if (Products.Count == 0)
            {
                Products.Add(new Product { Id = 1, Name = "Product 1", Price = 1 });
                Products.Add(new Product { Id = 2, Name = "Product 2", Price = 2 });
            }
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }

        public void Update(Product product)
        {
            var productToUpdateIndex = Products.FindIndex(s => s.Id == product.Id);

            Products[productToUpdateIndex].Name = product.Name;
            Products[productToUpdateIndex].Price = product.Price;
        }

        public void Delete(int Id)
        {
            var productToUpdateIndex = Products.FindIndex(s => s.Id == Id);

            Products.RemoveAt(productToUpdateIndex);
        }
    }
}