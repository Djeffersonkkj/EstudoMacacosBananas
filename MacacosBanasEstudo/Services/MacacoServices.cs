class MacacoServices
{
    private readonly Floresta _floresta;

    public MacacoServices(Floresta floresta)
    {
        _floresta = floresta;
    }
    public void CriarChimpanze(string nome)
    {
        Chimpanze novoChimpanze = new Chimpanze(nome);
        _floresta.AdicionarMacaco(novoChimpanze);
    }

    public void CriarSagui(string nome)
    {
        Sagui novoSagui = new Sagui(nome);
        _floresta.AdicionarMacaco(novoSagui);
    }

    public void CriarGorila(string nome)
    {
        Gorila novoGorila = new Gorila(nome);
        _floresta.AdicionarMacaco(novoGorila);
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