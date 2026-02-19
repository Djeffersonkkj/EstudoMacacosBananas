class Monster : Iconsumivel
{
    public string Sabor { get; private set; }
    public decimal Energia { get; private set; }

    public Monster(string sabor, decimal energia)
    {
        if (string.IsNullOrWhiteSpace(sabor))
        {
            throw new ArgumentException("O tipo não pode ser nulo ou conter apenas espaços.");
        }

        Sabor = sabor;
        Energia = energia;
    }

    public void Envenenar(decimal veneno)
    {
        if (Energia < 0)
        {
            Energia -= veneno;
        }
        else if (Energia >= 0)
        {
            Energia = -(Energia + veneno);
        }
    }

    public override string ToString()
    {
        return $"Monster: {Sabor} | Energia: {Energia}";
    }
}