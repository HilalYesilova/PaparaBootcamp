namespace PaparaApp.API.SOLID.DIP;

//Dependency Inversion Principle - Inversion of Control Prenciple => Dependency Injection design pattern
public interface IProductRepository
{
    void Save();
}

public class ProductRepository : IProductRepository //dependency object
{
    public void Save()
    {
        //save
    }
}

public class ProductRepositoryWithOracle : IProductRepository //dependency object
{
    public void Save()
    {
        //save
    }
}

public class ProductRepositoryFactory
{
    public IProductRepository GetInstance()
    {
        return new ProductRepository();
    }
}

public class ProductController //dependent object
{
    private readonly IProductRepository _repository; // dependency object

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Save()
    {
        _repository.Save();
    }
}

public class ProductServices
{
    private readonly IProductRepository _repository;

    public ProductServices(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Save()
    {
        _repository.Save();
    }
}