using System.Security.Cryptography;

class MainController
{
    public IconsumivelServices IconsumivelServices { get; private set; }
    public BolsaServices BolsaServices { get; private set; }
    public MacacoServices MacacoServices { get; private set; }

    public MainController(
        IconsumivelServices iconsumivelServices,
        BolsaServices bolsaServices,
        MacacoServices macacoServices)
    {
        IconsumivelServices = iconsumivelServices;
        BolsaServices = bolsaServices;
        MacacoServices = macacoServices;
    }
}