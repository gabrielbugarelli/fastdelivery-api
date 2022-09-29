using FastDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastDelivery.Infrastructure.EntityConfiguration;

public class ProductEntityConfig : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    var tableColumn = builder.ToTable("Products");

    tableColumn.HasKey(key => key.Id);

    tableColumn.Property(prop => prop.Name)
      .HasColumnType("varchar(200)")
      .IsRequired();

    tableColumn.Property(prop => prop.Description)
      .HasColumnType("varchar(700)")
      .IsRequired();

    tableColumn.Property(prop => prop.Active)
      .HasColumnType("boolean")
      .IsRequired();

    tableColumn.Property(prop => prop.Value)
      .HasColumnType("real")
      .IsRequired();

    tableColumn.Property(prop => prop.Registration)
      .IsRequired();

    tableColumn.Property(prop => prop.Type)
      .IsRequired();

    tableColumn.Property(prop => prop.QuantityStock)
      .IsRequired();
  }
}