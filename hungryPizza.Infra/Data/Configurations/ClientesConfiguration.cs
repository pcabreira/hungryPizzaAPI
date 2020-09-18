using hungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hungryPizza.Infra.Data.Configurations
{
    public class ClientesConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("idCliente");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false);

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Complemento)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Endereco)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Senha)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Telefone)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);
        }
    }
}
