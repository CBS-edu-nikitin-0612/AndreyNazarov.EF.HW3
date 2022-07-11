// See https://aka.ms/new-console-template for more information
internal class Appartment
{
    public int Number { get; set; }
    public int Square { get; set; }
    public int BuildingId { get; set; }
    public Building Building { get; set; }
    public override string ToString()
    {
        return $"Number: {Number}, Square: {Square}, Building: ({Building})";
    }
}
