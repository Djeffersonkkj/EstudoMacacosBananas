class Gorila : Macaco
{
    public Gorila(string nome) : base(nome, 200.0m, 0.5m){}

    public void Bater(Macaco alvo)
    {
        if (alvo == this)
        {
            throw new InvalidOperationException("Um macaco não pode bater em si mesmo.");
        }

        decimal energiaGasta = 12.5m;

        if (Energia <= energiaGasta)
        {
            throw new InvalidOperationException("Energia Insuficiente.");
        }

        decimal sorteio = Dado.Rolar(100);
        
        if (sorteio >= 25 * alvo.Agilidade)
        {
            alvo.GastarEnergia(25.00m);     
        }
        GastarEnergia(energiaGasta);
    }

    public override string UsarHabilidadeEspecial(Macaco alvo)
    {
        decimal energiaInicial = alvo.Energia;

        Bater(alvo);

        if (energiaInicial > alvo.Energia)
        {
            return $"O macaco {Nome} conseguiu bater em {alvo.Nome}.";
        }
        return $"O macaco {Nome} tentou bater em {alvo.Nome} e falhou.";
    }

    public override string ToString()
    {
        int limiteArmazenamento = BolsaVestida != null ? BolsaVestida.LimiteArmazenamento : 0;
        int quantidadeBananas = BolsaVestida != null ? BolsaVestida.Itens.Count : 0;

        return $"Gorila: {Nome} | BolsaVestida: {quantidadeBananas}/{limiteArmazenamento} | Energia: {Energia}";
    }
}