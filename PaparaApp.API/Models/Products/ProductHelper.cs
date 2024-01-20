namespace PaparaApp.API.Models.Products;

public class ProductHelper
{
    public decimal CalculateTax(decimal Price)
    {
        return Price * 0.20m;
    }
}

