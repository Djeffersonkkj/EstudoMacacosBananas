class MacacoView
{
    private readonly MainController _mainController;

    public MacacoView(MainController mainController)
    {
        _mainController = mainController;
    }

    public void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine(
            @"
                                -------------      Macacos      -------------
                            
            1  | Cadastrar Macaco
            2  | Ver Macacos

            3  | Pegar Bolsa
            4  | Largar Bolsa
            5  | Pegar Item
            6  | Comer Item
            7  | Dar Item

            8  | Usar Habilidade Especial

            0  | voltar");
    }

    public void Cadastrar()
    {
        try
        {
            string nomeMacaco;

            Console.Clear();
            Console.Write("Qual o nome do novo macaco? ");
            nomeMacaco = Console.ReadLine();

            Console.Clear();
            Console.Write(
                @"
                        
                1 | Chimpanzé
                2 | Gorila
                3 | Sagui

                Selecione a ESPECIE do macaco: ");

            string opcaoEspecie = Console.ReadLine();

            switch (opcaoEspecie)
            {
                case "1":
                    Console.Clear();
                    _mainController.MacacoServices.CriarChimpanze(nomeMacaco);
                    Console.WriteLine($"O macaco {nomeMacaco} chegou à floresta!");
                    break;

                case "2":
                    Console.Clear();
                    _mainController.MacacoServices.CriarGorila(nomeMacaco);
                    Console.WriteLine($"O macaco {nomeMacaco} chegou à floresta!");
                    break;

                case "3":
                    Console.Clear();
                    _mainController.MacacoServices.CriarSagui(nomeMacaco);
                    Console.WriteLine($"O macaco {nomeMacaco} chegou à floresta!");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public void ListarMacacos()
    {
        Console.Clear();
        IReadOnlyList<Macaco> macacos = _mainController.MacacoServices.ObterTodosMacacos();
        
        Console.WriteLine("Macacos na floresta:\n");
        for (int i = 0; i < macacos.Count; i++)
        {
            string MacacoDescricao = macacos[i].ToString();
            Console.WriteLine($"[{i}] {MacacoDescricao}");
        }
        Console.WriteLine();
    }

    public Macaco SelecionarMacaco(string acao)
    {
        int indexMacaco;
        Macaco macaco;

        Console.Write(acao);
        indexMacaco = int.Parse(Console.ReadLine());
        macaco = _mainController.MacacoServices.SelecionarMacacoPorIndex(indexMacaco);

        return macaco;
    }

    public void SoltarBolsa()
    {
        try
        {
            Macaco macaco;
            Bolsa bolsaLargada;

            ListarMacacos();
            macaco = SelecionarMacaco("Qual macaco vai largar a bolsa? ");

            Console.Clear();
            bolsaLargada = macaco.SoltarBolsa();
            _mainController.BolsaServices.DevolverBolsaParaFloresta(bolsaLargada);
            Console.WriteLine($"O macaco {macaco.Nome} largou sua bolsa na floresta");
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public Iconsumivel SelecionarItem(Macaco macaco, string acao)
    {
        int indexBanana;
        Bolsa bolsaDeBananas;
        Iconsumivel item;

        bolsaDeBananas = macaco.BolsaVestida;

        ListarBananas(macaco);
        Console.WriteLine(acao);
        indexBanana = int.Parse(Console.ReadLine());
        item = bolsaDeBananas.Itens[indexBanana];

        return item;
    }

    public void ListarBananas(Macaco macaco)
    {
        Console.Clear();

        IReadOnlyList<Iconsumivel> bananasNaBolsa = _mainController.MacacoServices.ObterItens(macaco);

        Console.WriteLine($"Bananas do {macaco.Nome}:\n");
        for (int i = 0; i < bananasNaBolsa.Count; i++)
        {
            String bananaDescricao = bananasNaBolsa[i].ToString();
            Console.WriteLine($"[{i}]  {bananaDescricao}");
        };
    }

    public void UsarHabilidadeEspecial()
    {
        try
        {
            Macaco atacante;
            Macaco alvo;
            string resultado;

            ListarMacacos();
            atacante = SelecionarMacaco("Qual macaco vai realizar a ação especial? ");

            ListarMacacos();
            alvo = SelecionarMacaco("Qual será o macaco alvo? ");

            Console.Clear();
            resultado = _mainController.MacacoServices.UsarHabilidadeEspecial(atacante, alvo);
            Console.WriteLine(resultado);
            if (alvo.Energia <= 0)
            {
                Console.WriteLine(resultado);
                _mainController.MacacoServices.MatarMacaco(alvo);
            }
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

}