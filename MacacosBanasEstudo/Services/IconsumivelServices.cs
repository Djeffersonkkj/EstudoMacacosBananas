class IconsumivelServices
{
    private readonly Floresta _floresta;

    public IconsumivelServices(Floresta floresta)
    {
        _floresta = floresta;
    }
    public void CriarBanana(string tipoBanana, decimal energiaBanana)
    {

        Banana novaBanana;

        novaBanana = new Banana(tipoBanana, energiaBanana);
        _floresta.AdicionarItem(novaBanana);
    }

    public IReadOnlyList<Iconsumivel> ObterTodosItens()
    {
        return _floresta.Itens;
    }

    public Iconsumivel SelecionarItemPorIndex(int index)
    {
        Iconsumivel itens = _floresta.Itens[index];
        return itens;
    }

    public void RemoveritemDaFloresta(Iconsumivel item)
    {
        _floresta.RemoverItem(item);
    }

}