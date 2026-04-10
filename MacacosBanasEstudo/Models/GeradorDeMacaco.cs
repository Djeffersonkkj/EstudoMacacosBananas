using System.Runtime.CompilerServices;
using MacacosBanasEstudo.Enums;

class GeradorDeMacaco
{
    private static readonly Dictionary<TipoMacaco, Func<string, Macaco>>
        _geradorDeMacacos = new();

    public static void Inicializar()
    {
        RuntimeHelpers.RunClassConstructor(typeof(Chimpanze).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(Sagui).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(Gorila).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(Bruxo).TypeHandle);
    }

    public static void AdicionarGerador(
        TipoMacaco tipo,
        Func<string, Macaco> criar)
    {
        _geradorDeMacacos[tipo] = criar;
    }

    public static Macaco CriarMacaco(string nome, TipoMacaco tipo)
    {
        if (!_geradorDeMacacos.TryGetValue(tipo, out var gerador))
            throw new Exception($"Tipo não registrado: {tipo}");

        return gerador(nome);
    }
}