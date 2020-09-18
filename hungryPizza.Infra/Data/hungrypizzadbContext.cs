using hungryPizza.Core.Entities;
using hungryPizza.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace hungryPizza.Infra.Data
{
    public partial class hungrypizzadbContext : DbContext
    {
        public hungrypizzadbContext(DbContextOptions<hungrypizzadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<PedidoDetalhe> PedidoDetalhe { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientesConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoDetalheConfiguration());
            modelBuilder.ApplyConfiguration(new PedidosConfiguration());
            modelBuilder.ApplyConfiguration(new PizzasConfiguration());
        }
    }
}
