class Bolsa
{  
    private readonly List<Iconsumivel> _itens = [];

    public string Material { get; private set; }
    public int LimiteArmazenamento { get; private set; }
    public IReadOnlyList<Iconsumivel> Itens => _itens;

    public Bolsa(string material, int limiteArmazenamento)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(material);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(limiteArmazenamento);

        Material = material;
        LimiteArmazenamento = limiteArmazenamento;
        _itens = [];
    }

    public void Armazenaritem(Iconsumivel item)
    {
        if (_itens.Count == LimiteArmazenamento)
        {
            throw new InvalidOperationException("Limite de armazenamento atingido.");
        }
        _itens.Add(item);
    }

    public void RemoverItem(Iconsumivel item)
    {
        _itens.Remove(item);
    }

    public override string ToString()
    {
        return $"Material: {Material} | Armazenamento: {_itens.Count}/{LimiteArmazenamento}";
    }

}