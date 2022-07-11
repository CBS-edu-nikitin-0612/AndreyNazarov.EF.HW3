// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Building building1 = new Building() { Address = "Address 1", Type = "Wood" };
Building building2 = new Building() { Address = "Address 2", Type = "Stone" };

Appartment appartment1 = new Appartment() { Number = 1, Square = 60 };
Appartment appartment2 = new Appartment() { Number = 2, Square = 40 };
Appartment appartment3 = new Appartment() { Number = 3, Square = 70 };
Appartment appartment4 = new Appartment() { Number = 4, Square = 23 };
Appartment appartment5 = new Appartment() { Number = 1, Square = 65 };
Appartment appartment6 = new Appartment() { Number = 2, Square = 54 };
Appartment appartment7 = new Appartment() { Number = 3, Square = 78 };

building1.Appartments.Add(appartment1);
building1.Appartments.Add(appartment2);
building1.Appartments.Add(appartment3);
building1.Appartments.Add(appartment4);

building2.Appartments.Add(appartment5);
building2.Appartments.Add(appartment6);
building2.Appartments.Add(appartment7);

using (Context context = new Context())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    context.Buildings.AddRange(building1, building2);
    context.Appartments.AddRange(appartment1, appartment2, appartment3, appartment4, appartment5, appartment6, appartment7);
    context.SaveChanges();
}

using (Context context = new Context())
{
    Console.WriteLine("Buildings");
    foreach (Building building in context.Buildings.Include(b => b.Appartments))
    {
        Console.WriteLine(building);
    }
    Console.WriteLine("\nAppartments");
    foreach (Appartment appartment in context.Appartments)
    {
        Console.WriteLine(appartment);
    }
}
