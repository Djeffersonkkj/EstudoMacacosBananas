class Chimpanze : Macaco
{
    public Chimpanze(string nome) : base(nome, 100.0m, 1.0m){}

    public void EnvenenarComida(Macaco alvo)
    {
        decimal energiaGasta = 10.0m;
        Bolsa bolsaAlvo = alvo.BolsaVestida;
        int quantidadeItensNaBolsa = bolsaAlvo.Itens.Count;
        int sorteioItens = Dado.RolarIndex(quantidadeItensNaBolsa);
        Iconsumivel comidaEnvenenada = bolsaAlvo.Itens[sorteioItens];

        if (Energia <= energiaGasta)
        {
            throw new InvalidOperationException("Energia Insuficiente.");
        }

        comidaEnvenenada.Envenenar(15);
        GastarEnergia(energiaGasta);
    }

    public override string UsarHabilidadeEspecial(Macaco alvo)
    {
        EnvenenarComida(alvo);
        if (alvo == this)
        {
            return $"O chimpanzé {Nome} envenenou o propria banana";
        }
        return $"O chimpanzé {Nome} envenenou um item de {alvo.Nome}";
    }

    public override string ToString()
    {
        int limiteArmazenamento = BolsaVestida != null ? BolsaVestida.LimiteArmazenamento : 0;
        int quantidadeBananas = BolsaVestida != null ? BolsaVestida.Itens.Count : 0;

        return $"Chimpanzé: {Nome} | BolsaVestida: {quantidadeBananas}/{limiteArmazenamento} | Energia: {Energia}";
    }
}