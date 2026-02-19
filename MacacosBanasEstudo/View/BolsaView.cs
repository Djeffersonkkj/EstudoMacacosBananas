class BolsaView
{
    private readonly MainController _mainController;

    public BolsaView(MainController mainController)
    {
        _mainController = mainController;
    }

    public void CadastrarBolsa()
    {
        try
        {
            string material;
            int armazenamentoLimite;

            Console.Clear();
            Console.Write("Qual o material da bolsa? ");
            material = Console.ReadLine();
            Console.Write("Qual o limite da nova bolsa? ");
            armazenamentoLimite = int.Parse(Console.ReadLine());

            _mainController.BolsaServices.CriarBolsa(material, armazenamentoLimite);

            Console.Clear();
            Console.WriteLine($"Uma bolsa de {material} brotou na floresta!");
            
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public void ListarBolsas()
    {
        Console.Clear();
        IReadOnlyList<Bolsa> bolsas = _mainController.BolsaServices.ObterTodasBolsas();

        Console.WriteLine("Bolsas no chão:\n");
        for (int i = 0; i < bolsas.Count; i++)
        {
            string DescricaoBolsa = bolsas[i].ToString();
            Console.WriteLine($"[{i}] {DescricaoBolsa}");
        }
        Console.WriteLine();
    }

    public Bolsa SelecionarBolsa(string acao)
    {
        int indexBolsaVestida;
        Bolsa bolsaVestida;

        Console.Write(acao);
        indexBolsaVestida = int.Parse(Console.ReadLine());
        bolsaVestida = _mainController.BolsaServices.SelecionarBolsaPorIndex(indexBolsaVestida);
        return bolsaVestida;
    }

    
}