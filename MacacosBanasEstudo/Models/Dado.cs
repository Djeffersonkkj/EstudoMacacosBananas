static class Dado
{
    private static readonly Random _random = new Random();

    public static int Rolar(int lados)
    {
        int resultado = _random.Next(1, lados + 1);
        return resultado;
    }
    public static int RolarIndex(int lados)
    {
        int resultado = _random.Next(lados);
        return resultado;
    }
}