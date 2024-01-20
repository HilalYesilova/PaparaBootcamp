namespace PaparaApp.API.Models.Products;

public static class ProductDIContainerExt
{
    public static void AddProductDIContainer(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ProductHelper>();
    }
}
