namespace PaparaApp.API.Extensions;

public static class StringExt
{
    //string type

    public static string GetFullName(this string text, string surname)
    {
        return $"{text} {surname}";
    }
}