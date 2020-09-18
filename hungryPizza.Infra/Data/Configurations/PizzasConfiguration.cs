using hungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hungryPizza.Infra.Data.Configurations
{
    public class PizzasConfiguration : IEntityTypeConfiguration<Pizzas>
    {
        public void Configure(EntityTypeBuilder<Pizzas> builder)
        {
            builder.ToTable("Pizzas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("idPizza");

            builder.Property(e => e.Sabor)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Valor)
                .IsRequired()
                .HasColumnType("decimal(5, 2)");
        }
    }
}
