using hungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hungryPizza.Infra.Data.Configurations
{
    public class PedidosConfiguration : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("idPedido");

            builder.Property(e => e.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(5, 2)");

            builder.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_Clientes");
        }
    }
}
