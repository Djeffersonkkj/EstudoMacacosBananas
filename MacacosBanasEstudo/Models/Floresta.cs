class Floresta
{
    private readonly List<Macaco> _macacos = [];
    private readonly List<Iconsumivel> _itens = [];
    private readonly List<Bolsa> _bolsas = [];

    public IReadOnlyList<Macaco> Macacos => _macacos;
    public IReadOnlyList<Iconsumivel> Itens => _itens;
    public IReadOnlyList<Bolsa> Bolsas => _bolsas;
    

    public void AdicionarMacaco(Macaco macaco)
    {
        _macacos.Add(macaco);
    }

    public void RemoverMacaco(Macaco macaco)
    {
        _macacos.Remove(macaco);
    }

    public void AdicionarItem(Iconsumivel item)
    {
        _itens.Add(item);
    }

    public void RemoverItem(Iconsumivel item)
    {
        _itens.Remove(item);
    }

    public void AdicionarBolsa(Bolsa Bolsa)
    {
        _bolsas.Add(Bolsa);
    }

    public void ReceberBolsa(Bolsa bolsa)
    {
        _bolsas.Add(bolsa);
    }

    public void RemoverBolsa(Bolsa bolsa)
    {
        _bolsas.Remove(bolsa);
    }


}