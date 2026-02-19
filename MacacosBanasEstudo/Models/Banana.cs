class Banana : Iconsumivel
{
    public string Tipo { get; private set; }
    public decimal Energia { get; private set; }

    public Banana(string tipo, decimal energia)
    {
        if (string.IsNullOrWhiteSpace(tipo))
        {
            throw new ArgumentException("O tipo não pode ser nulo ou conter apenas espaços.");
        }

        Tipo = tipo;
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
        return $"Banana: {Tipo} | Energia: {Energia}";
    }
}