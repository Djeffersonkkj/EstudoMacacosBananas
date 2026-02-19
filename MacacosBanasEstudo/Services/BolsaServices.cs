class BolsaServices
{
    private readonly Floresta _floresta;

    public BolsaServices(Floresta floresta)
    {
        _floresta = floresta;
    }
    public void CriarBolsa(string material, int armazenamentoLimite)
    {
        
        Bolsa novaBolsa;

        novaBolsa = new Bolsa(material, armazenamentoLimite);
        _floresta.AdicionarBolsa(novaBolsa);

    }

    public IReadOnlyList<Bolsa> ObterTodasBolsas()
    {
        return _floresta.Bolsas;
    }

    public Bolsa SelecionarBolsaPorIndex(int index)
    {
        Bolsa bolsa = _floresta.Bolsas[index];
        return bolsa;
    }

    public void RemoverBolsaFloresta(Bolsa bolsa)
    {
        _floresta.RemoverBolsa(bolsa);
    }

    public void DevolverBolsaParaFloresta(Bolsa bolsa)
    {
        _floresta.ReceberBolsa(bolsa);
    }
}