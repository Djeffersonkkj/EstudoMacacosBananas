using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MacacosBanasEstudo.Enums;

namespace MacacosBanasEstudo.Models;

class GeradorDeMacaco
{
    private static readonly Dictionary<TipoMacaco, Func<string, Macaco>> _geradorDeMacacos = new();

    public static void AdicionarGerador(TipoMacaco tipo, Func<string, Macaco> criar)
    {
        _geradorDeMacacos[tipo] = criar;
    }

    public static Macaco CriarMacaco(string nome, TipoMacaco tipo)
    {
        return _geradorDeMacacos[tipo](nome);
    }
}
