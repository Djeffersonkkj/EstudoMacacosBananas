using System.Security.AccessControl;

class MainView
{
    private readonly MainController _mainController;
    public MacacoView MacacoView { get; private set; }
    public BolsaView BolsaView { get; private set; }
    public IconsumivelView BananaView { get; private set; }

    public MainView(
        MainController mainController,
        MacacoView macacoView,
        BolsaView bolsaView,
        IconsumivelView bananaView)
    {
        _mainController = mainController;
        MacacoView = macacoView;
        BolsaView = bolsaView;
        BananaView = bananaView;
    }

    public void ExibirMenu()
    {
        Console.WriteLine(
            @"
                                ------------- Macacos e Bananas -------------
                            
            1 | Macaco
            2 | Cadastrar Banana
            3 | Cadastrar Bolsa

            0 | Fechar Sistema");
    }
    public void ExibirMacacos()
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
        Console.Write("Enter para voltar...");
        Console.ReadKey();
        Console.Clear();
    }

    public void PegarBolsa()
    {
        try
        {
            Macaco macacoPegador;
            Bolsa bolsaVestida;


            MacacoView.ListarMacacos();
            macacoPegador = MacacoView.SelecionarMacaco("Qual macaco vai pegar a bolsa? ");

            BolsaView.ListarBolsas();
            bolsaVestida = BolsaView.SelecionarBolsa($"Qual bolsa o {macacoPegador.Nome} vai pegar? ");
            
            Console.Clear();
            macacoPegador.VestirBolsa(bolsaVestida);
            Console.WriteLine($"O macaco {macacoPegador.Nome} pegou uma bolsa de {bolsaVestida.Material}");
            _mainController.BolsaServices.RemoverBolsaFloresta(bolsaVestida);
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public void PegarItem()
    {
        try
        {
            Macaco macacoPegador;
            Iconsumivel itemPego;

            MacacoView.ListarMacacos();
            macacoPegador = MacacoView.SelecionarMacaco("Qual o macaco que vai pegar o item? ");

            BananaView.ListarItens();
            itemPego = BananaView.SelecionarItemFloresta($"Qual item o {macacoPegador.Nome} vai pegar? ");

            Console.Clear();
            macacoPegador.Pegaritem(itemPego);
            Console.WriteLine($"O macaco {macacoPegador.Nome} pegou um item.");
            _mainController.IconsumivelServices.RemoveritemDaFloresta(itemPego);
            
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public void ComerItem()
    {
        try
        {
            
            Macaco macacoComedor;
            Iconsumivel itemComido;

            MacacoView.ListarMacacos();
            macacoComedor = MacacoView.SelecionarMacaco("Qual macaco vai comer o item? ");
            
            MacacoView.ListarBananas(macacoComedor);
            itemComido = MacacoView.SelecionarItem(macacoComedor, "Qual item será comido? ");

            Console.Clear();
            Console.WriteLine($"O macaco {macacoComedor.Nome} Comeu algo e recebeu {itemComido.Energia} em energia.");
            macacoComedor.ComerConsumivel(itemComido);
            if (macacoComedor.Energia <= 0)
            {
                Console.WriteLine($"O macaco {macacoComedor.Nome} comeu um item ruim e morreu.");
                _mainController.MacacoServices.MatarMacaco(macacoComedor);
            }
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    public void DarItem()
    {
        try
        {
            Macaco macacoRemetente;
            Iconsumivel itemDoado;
            Macaco macacoDestinatario;
            Bolsa bolsa;

            MacacoView.ListarMacacos();
            macacoRemetente = MacacoView.SelecionarMacaco("Qual macaco vai dar a banana? ");
            bolsa = macacoRemetente.BolsaVestida;

            MacacoView.ListarBananas(macacoRemetente);
            itemDoado = MacacoView.SelecionarItem(macacoRemetente, $"Qual banana o {macacoRemetente.Nome} vai dar? ");

            MacacoView.ListarMacacos();
            macacoDestinatario = MacacoView.SelecionarMacaco("Qual macaco vai receber a banana? ");

            Console.Clear();
            macacoRemetente.DarItem(macacoDestinatario, itemDoado);
            Console.WriteLine($"O macaco {macacoRemetente.Nome} deu um item para {macacoDestinatario}");
        }
        catch (System.Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    
}