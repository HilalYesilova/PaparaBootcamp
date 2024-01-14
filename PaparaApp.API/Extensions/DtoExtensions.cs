using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Extensions;

public static class DtoExtensions
{
    public static List<ProductDto> ToDtoList(this List<Product> products)
    {
        return products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();
    }

    public static string BuyukHarfYap(this string text)
    {
        return text.ToUpper();
    }
}
