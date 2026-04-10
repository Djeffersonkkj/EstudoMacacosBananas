using MacacosBanasEstudo.Enums;

class Bruxo : Macaco
{
    public Bruxo(string nome) : base(nome, 100m, 1.2m){}

    static Bruxo()
    {
        GeradorDeMacaco.AdicionarGerador(TipoMacaco.Bruxo, (nome) => new Bruxo(nome));
    }

    public override TipoMacaco tipo => TipoMacaco.Bruxo;

    private void TransformarMacacoEmBanana(Macaco alvo)
    {
        if (alvo == this)
        {
            throw new InvalidOperationException("Um macaco não pode se transformar em banana.");
        }

        if (BolsaVestida == null)
        {
            throw new InvalidOperationException("O macaco precisa estar usando uma bolsa para transformar o outro em banana.");
        }

        if (BolsaVestida.LimiteArmazenamento == BolsaVestida.Itens.Count)
        {
            throw new InvalidOperationException("O macaco precisa ter um espaço livre na bolsa para transformar o outro em banana");
        }

        decimal energiaGasta = 80m;

        if (Energia <= energiaGasta)
        {
            throw new InvalidOperationException("Energia Insuficiente.");
        }

        decimal sorteio = Dado.Rolar(100);
        
        if (sorteio >= 20 * alvo.Agilidade)
        {
            Banana banana = new Banana(alvo.Nome, alvo.Energia);
            alvo.GastarEnergia(alvo.Energia);
            BolsaVestida.Armazenaritem(banana);
        }
        GastarEnergia(energiaGasta);
    }

    public override string UsarHabilidadeEspecial(Macaco alvo)
    {
        decimal energiaInicial = alvo.Energia;

        TransformarMacacoEmBanana(alvo);

        if (energiaInicial > alvo.Energia)
        {
            return $"O macaco {Nome} transformou {alvo.Nome} em uma banana.";
        }
        return $"O macaco {Nome} tentou transformar {alvo.Nome} em uma banana e falhou."; 
    }

    public override string ToString()
    {
        int limiteArmazenamento = BolsaVestida != null ? BolsaVestida.LimiteArmazenamento : 0;
        int quantidadeBananas = BolsaVestida != null ? BolsaVestida.Itens.Count : 0;

        return $"Bruxo: {Nome} | BolsaVestida: {quantidadeBananas}/{limiteArmazenamento} | Energia: {Energia}";
    }
}