// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class AppartemntConfiguring : IEntityTypeConfiguration<Appartment>
{
    public void Configure(EntityTypeBuilder<Appartment> builder)
    {
        builder.HasKey(a => new { a.Number, a.BuildingId });
    }
}
