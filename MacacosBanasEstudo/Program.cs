Floresta floresta = new();
IconsumivelServices iconsumivelServices = new(floresta);
BolsaServices bolsaServices = new(floresta);
MacacoServices macacoServices = new(floresta);

MainController Controller = new(
    iconsumivelServices,
    bolsaServices,
    macacoServices);
    
InicializadorDados inicializador = new(Controller, floresta);
inicializador.Semear();


MacacoView macacoView = new(Controller);
BolsaView bolsaView = new(Controller);
IconsumivelView iconsumivelView = new(Controller); 
MainView mainView = new(
    Controller, 
    macacoView, 
    bolsaView, 
    iconsumivelView);

bool loop = true;

while (loop)
{
    string opcao;

    mainView.ExibirMenu();
    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "0":
            Console.Clear();
            Console.WriteLine("Sistema Fechado!");
            loop = false;
            break;

        case "1":
            macacoView.ExibirMenu();
            string opcaoMacaco = Console.ReadLine();
            switch (opcaoMacaco)
            {
                case "0":
                    Console.Clear();
                    break;

                case "1":
                    macacoView.Cadastrar();
                    break;

                case "2":
                    mainView.ExibirMacacos();
                    break;

                case "3":
                    mainView.PegarBolsa();
                    break;

                case "4":
                    macacoView.SoltarBolsa();
                    break;

                case "5":
                    mainView.PegarItem();
                    break;

                case "6":
                    mainView.ComerItem();
                    break;

                case "7":
                    mainView.DarItem();
                    break;

                case "8":
                    macacoView.UsarHabilidadeEspecial();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opçao inválida!");
                    break;
            }
            break;

        case "2":
            iconsumivelView.CadastrarBanana();
            break;

        case "3":
            bolsaView.CadastrarBolsa();
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opçao inválida!");
            break;
    }
}