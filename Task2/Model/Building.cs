// See https://aka.ms/new-console-template for more information
internal class Building
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
    public HashSet<Appartment> Appartments { get; set; } = new HashSet<Appartment>();

    public override string ToString()
    {
        return $"Id: {Id}, Address: {Address}, Type: {Type}, Appartments count: {Appartments.Count}";
    }
}
