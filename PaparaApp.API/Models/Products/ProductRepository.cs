namespace PaparaApp.API.Models.Products
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new();

        public ProductRepository()
        {
            if (Products.Count == 0)
            {
                Products.Add(new Product { Id = 1, Name = "Product 1", Price = 100 });
                Products.Add(new Product { Id = 2, Name = "Product 2", Price = 200 });
                Products.Add(new Product { Id = 3, Name = "Product 3", Price = 300 });
                Products.Add(new Product { Id = 4, Name = "Product 4", Price = 400 });
            }
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public Product Add(Product product)
        {
            Products.Add(product);
            return product;
        }

        public void Update(Product product)
        {
            var productToUpdateIndex = Products.FindIndex(p => p.Id == product.Id);

            Products[productToUpdateIndex].Name = product.Name;
            Products[productToUpdateIndex].Price = product.Price;
        }

        public void Delete(int id)
        {
            var productToDeleteIndex = Products.FindIndex(p => p.Id == id);
            Products.RemoveAt(productToDeleteIndex);
        }
    }
}