class Sagui : Macaco
{
    public Sagui(string nome) : base(nome, 60.0m, 2.0m){}

    public void RoubarBolsa(Macaco alvo)
    {

        if (alvo == this)
        {
            throw new InvalidOperationException("Não pode roubar de si mesmo.");
        }

        if (alvo.BolsaVestida == null)
        {
            throw new InvalidOperationException("A vítima não tem bolsa");
        }

        decimal energiaGasta = 10.0m;

        if (Energia <= energiaGasta)
        {
            throw new InvalidOperationException("Energia Insuficiente.");
        }

        VestirBolsa(alvo.SoltarBolsa());
        GastarEnergia(energiaGasta);
    }

    public override string UsarHabilidadeEspecial(Macaco alvo)
    {
        RoubarBolsa(alvo);
        return $"O sagui {Nome} roubou a bolsa de {alvo.Nome}";
    }

    public override string ToString()
    {
        int limiteArmazenamento = BolsaVestida != null ? BolsaVestida.LimiteArmazenamento : 0;
        int quantidadeBananas = BolsaVestida != null ? BolsaVestida.Itens.Count : 0;

        return $"Sagui: {Nome} | BolsaVestida: {quantidadeBananas}/{limiteArmazenamento} | Energia: {Energia}";
    }
}