using PaparaApp.API.Models.Products;

namespace PaparaApp.API.TwoDay.InterfaceExample;

//high cohesion low coupling
//observer design pattern
//mediator design pattern
// Abstractions
//  soyut => intercace,abstract class

// interface => contract => imzalı metotlar

public class AController
{
    // var a=5
    // a="ahmet"


    private readonly IRepository productRepository = new ProductRepositoryWithOracle();

    public void Add(Product product)
    {
        productRepository.GetAll();
    }
}

public interface IRepository
{
    public int Id { get; set; }

    // method signature + method behavior
    List<Product> GetAll();
    Product GetById(int id);
}

public interface IHelper
{
    string FullName(string name, string surname);
}

// Repository/Service/Helper => new()  interface

public class BaseRepository
{
    public int Name { get; set; }

    public int CalculateTax()
    {
        return 10;
    }
}

public class ProductRepositoryWithOracle : IRepository

{
    public int Id
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }
}

public interface ICalculateService
{
}

public class CalculateService
{
    public int CalculateTax()
    {
        return 10;
    }
}

public class ProductRepository : IRepository
{
    public int Id { get; set; }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }


    public void Add(Product product)
    {
        // Sql Server
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}