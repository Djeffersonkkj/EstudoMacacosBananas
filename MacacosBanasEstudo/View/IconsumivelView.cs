class IconsumivelView
{
    private readonly MainController _mainController;

    public IconsumivelView(MainController mainController)
    {
        _mainController = mainController;
    }

    public void CadastrarBanana()
    {
        try
        {
            string tipoBanana;
            decimal energiaBanana;

            Console.Clear();
            Console.Write("Qual o tipo da nova banana? ");
            tipoBanana = Console.ReadLine();
            Console.Write("Quanta energia a banana dá? ");
            energiaBanana = decimal.Parse(Console.ReadLine());

            _mainController.IconsumivelServices.CriarBanana(tipoBanana, energiaBanana);

            Console.Clear();
            Console.WriteLine($"Uma banana {tipoBanana} brotou na floresta!");
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public void ListarItens()
    {
        Console.Clear();
        IReadOnlyList<Iconsumivel> itens = _mainController.IconsumivelServices.ObterTodosItens();
        Console.WriteLine("Bananas nas bananeiras:\n");
        for (int banana = 0; banana < itens.Count; banana++)
        {
            string DescricaoBanana = itens[banana].ToString();
            Console.WriteLine($"[{banana}] {DescricaoBanana}");
        }
        Console.WriteLine();
    }

    public Iconsumivel SelecionarItemFloresta(string acao)
    {
        int indexBanana;
        Iconsumivel bananaPega;

        Console.Write(acao);
        indexBanana = int.Parse(Console.ReadLine());
        bananaPega = _mainController.IconsumivelServices.SelecionarItemPorIndex(indexBanana);

        return bananaPega;
    }
}