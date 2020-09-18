using hungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hungryPizza.Infra.Data.Configurations
{
    public class PedidoDetalheConfiguration : IEntityTypeConfiguration<PedidoDetalhe>
    {
        public void Configure(EntityTypeBuilder<PedidoDetalhe> builder)
        {
            builder.ToTable("PedidoDetalhe");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("idPedidoDetalhe");

            builder.Property(e => e.NomePizza1)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NomePizza2)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ValorPizza1)
                .IsRequired()
                .HasColumnType("decimal(5, 2)");

            builder.Property(e => e.ValorPizza2)
                .HasColumnType("decimal(5, 2)");

            builder.HasOne(d => d.IdPedidoNavigation)
                .WithMany(p => p.PedidoDetalhe)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Detalhe");
        }
    }
}
