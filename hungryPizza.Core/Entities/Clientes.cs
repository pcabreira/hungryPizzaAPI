using System;
using System.Collections.Generic;

namespace hungryPizza.Core.Entities
{
    public partial class Clientes : BaseEntity
    {
        public Clientes()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Pedidos> Pedidos { get; set; }

        public Clientes(int id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
