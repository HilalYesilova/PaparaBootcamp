namespace PaparaApp.API.SOLID.ISP;

//  2 module  ReadModule , WriteModule

public class ReadModule
{
    private readonly IReadProductRepository _repository;

    public ReadModule(IReadProductRepository repository)
    {
        _repository = repository;
    }

    public List<string> GetAll()
    {
        return _repository.GetAll();
    }
}

// GOD CLASS
public class StringHelper
{
    public string GetFullName(string name, string surname)
    {
        return name + " " + surname;
    }

    public string GetFullName(string name, string surname, string title)
    {
        return title + " " + name + " " + surname;
    }
}

public class CalculateHelper
{
    public int CalculateKdv(int id, int price)
    {
        return price * 18 / 100;
    }
}

public class WriteModule
{
    private readonly IWriteProductRepository _repository;

    public WriteModule(IWriteProductRepository repository)
    {
        _repository = repository;
    }

    public void Save()
    {
        _repository.Save();
    }

    public void Update()
    {
        _repository.Update();
    }

    public void Delete()
    {
        _repository.Delete();
    }
}

public interface IReadProductRepository
{
    List<string> GetAll();
    string GetById(int id);
}

public interface IWriteProductRepository
{
    void Save();
    void Update();
    void Delete();
}

public class AModule
{
}

public interface IAModuleProductRepository
{
    List<string> GetAll();
}

public interface IProductRepository
{
    List<string> GetAll();
    void Save();
    void Update();
    void Delete();
    string GetById(int id);
}

public class ProductRepository : IReadProductRepository, IWriteProductRepository, IAModuleProductRepository
{
    public List<string> GetAll()
    {
        return new List<string>();
    }

    public string GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }
}