namespace PaparaApp.API.Extensions;

public static class IntExt
{
    //int type

    public static double CalculateTax(this double price)
    {
        return price * 0.20;
    }
}