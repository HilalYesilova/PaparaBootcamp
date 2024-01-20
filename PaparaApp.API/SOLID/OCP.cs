namespace PaparaApp.API.SOLID.OCP;

public class ProductController
{
    public ProductController()
    {
        var productService = new ProductService(new ProductRepositoryWithOracle());

        productService.GetNames();
    }
}

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<string> GetNames()
    {
        return _repository.GetNames();
    }
}

public interface IProductRepository
{
    List<string> GetNames();

    void MakeToRequest();
}

public class ProductRepository : IProductRepository

{
    public List<string> GetNames()
    {
        //sql connection
        //sql command
        //
        return ["kalem", "kitap", "defter"];
    }

    public void MakeToRequest()
    {
        throw new NotImplementedException();
    }
}

public class ProductRepositoryWithOracle : IProductRepository

{
    public List<string> GetNames()
    {
        //oracle connection
        //oracle command
        // stockId
        MakeToRequest();
        //
        return ["o kalem", "o kitap", "o defter"];
    }

    public void MakeToRequest()
    {
        throw new NotImplementedException();
    }
}