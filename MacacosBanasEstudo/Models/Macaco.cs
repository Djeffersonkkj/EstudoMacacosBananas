using System.ComponentModel;

 abstract class Macaco
{
    public string Nome { get; private set; }
    public Bolsa BolsaVestida { get; private set; }
    public decimal Energia { get; protected set; }
    public decimal Agilidade { get; protected set; }
    protected decimal _limiteEnergia;

    public Macaco(string nome, decimal limiteEnergia, decimal agilidade)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome não pode ser nulo ou conter apenas espaços.");
        }
        Nome = nome;
        BolsaVestida = null;
        Energia = limiteEnergia;
        Agilidade = agilidade;
        _limiteEnergia = limiteEnergia;
    }

    public void VestirBolsa(Bolsa bolsa)
    {
        if (BolsaVestida != null)
        {
            throw new InvalidOperationException("Não é possível vestir mais de uma bolsa.");
        }
        BolsaVestida = bolsa;
    }

    public void Pegaritem(Iconsumivel item)
    {
        decimal energiaGasta = 1.0m;

        if (Energia <= energiaGasta)
        {
            throw new InvalidOperationException("Energia Insuficiente.");
        }
        
        BolsaVestida.Armazenaritem(item);
        GastarEnergia(energiaGasta);
    }

    public void ComerConsumivel(Iconsumivel comida)
    {
        IReadOnlyList<Iconsumivel> bananasNaBolsa = BolsaVestida.Itens;

        if (bananasNaBolsa.Count == 0)
        {
            throw new InvalidOperationException("O macaco não possui bananas para comer.");
        } 
        if (Energia == _limiteEnergia)
        {
            throw new InvalidOperationException("Limite de energia atingido");
        }

        Energia = Math.Min(Energia + comida.Energia, _limiteEnergia);
        BolsaVestida.RemoverItem(comida);
    }

    public void DarItem( Macaco destinatario, Iconsumivel item)
    {
        Bolsa bolsaDestinatario = destinatario.BolsaVestida;

        bolsaDestinatario.Armazenaritem(item);
        BolsaVestida.RemoverItem(item);
    }

    public Bolsa SoltarBolsa()
    {
        if (BolsaVestida == null)
        {
            throw new InvalidOperationException("É necessário estar vestindo uma bolsa para soltar.");
        }

        Bolsa bolsaLargada = BolsaVestida;
        BolsaVestida = null;

        return bolsaLargada;
    }

    public void GastarEnergia(decimal energiaGasta)
    {
        Energia -= energiaGasta;
    }

    public abstract string UsarHabilidadeEspecial (Macaco alvo);

}