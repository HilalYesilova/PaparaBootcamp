namespace PaparaApp.API.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; //null değer olmaz desek de yazılımsal olarak bu referans tipine null değer geçebiliriz. Compiler exception fırlatmaz uyarı verir.
        public decimal Price { get; set; }
    }
}
