using System.Text;

namespace PaparaApp.API.TwoDay;

public class WriteAttribute
{
    public void WriteComputerAttribute()
    {
        //c# reflection

        var type = typeof(GameComputerType);
        var attributes = type.GetCustomAttributes(false);
        foreach (var attribute in attributes)
            if (attribute is ComputerComponents computerComponents)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"CPU: {computerComponents.CPU}");
                sb.AppendLine($"GPU: {computerComponents.GPU}");
                Console.WriteLine(sb.ToString());
            }
    }
}

public class Author : Attribute
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Version { get; set; }
}

public class ComputerComponents : Attribute
{
    public string CPU { get; set; }
    public string GPU { get; set; }
}

[Author(FirstName = "Mehmet", LastName = "KARATAŞ", Version = "1.0")]
public class Book1
{
    public string Name { get; set; }

    public int PageCount { get; set; }
}

[ComputerComponents(CPU = "i7", GPU = "4060")]
public class GameComputerType
{
}