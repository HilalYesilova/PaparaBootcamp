namespace PaparaApp.API.TwoDay.AbstractExample;

public class ProductService
{
    public ProductService()
    {
        var product = new Product();
    }
}

public abstract class BaseEntity
{
    public int Id { get; set; }

    public int CalculateTax()
    {
        return 10;
    }
}

public class Product : BaseEntity
{
    public string Name { get; set; }
}

public class Stock : BaseEntity
{
    public int Count { get; set; }
}

public abstract class Repository
{
    public abstract List<string> GetAll();
}