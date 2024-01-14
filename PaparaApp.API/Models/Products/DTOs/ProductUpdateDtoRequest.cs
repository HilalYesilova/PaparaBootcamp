namespace PaparaApp.API.Models.Products.DTOs
{
    public class ProductUpdateDtoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
