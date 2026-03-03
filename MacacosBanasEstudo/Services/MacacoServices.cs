using MacacosBanasEstudo.Enums;

class MacacoServices
{
    private readonly Floresta _floresta;

    public MacacoServices(Floresta floresta)
    {
        _floresta = floresta;
    }

    public void CriarMacaco(string nome,TipoMacaco tipo)
    {
        Macaco novoMacaco = GeradorDeMacaco.CriarMacaco(nome, tipo);
        _floresta.AdicionarMacaco(novoMacaco);
    }

    public IReadOnlyList<Iconsumivel> ObterItens(Macaco macaco)
    {
        Bolsa bolsa = macaco.BolsaVestida;
        return bolsa.Itens;
    }

    public IReadOnlyList<Macaco> ObterTodosMacacos()
    {
        return _floresta.Macacos;
    }

    public Macaco SelecionarMacacoPorIndex(int index)
    {
        Macaco macaco = _floresta.Macacos[index];
        return macaco;
    }

    public void MatarMacaco(Macaco macaco)
    {
        if (macaco.BolsaVestida != null)
        {
            Bolsa bolsa = macaco.SoltarBolsa(); 
            _floresta.AdicionarBolsa(bolsa);
        }
        _floresta.RemoverMacaco(macaco);
    }

    public string UsarHabilidadeEspecial(Macaco macacoAtacante, Macaco alvo)
    {
        string resultado;
        resultado = macacoAtacante.UsarHabilidadeEspecial(alvo);

        return resultado;
    }
}