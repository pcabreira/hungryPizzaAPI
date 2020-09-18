using hungryPizza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace hungryPizza.Test.Builder
{
    public class ClientesBuilder
    {
        public Clientes GetCliente(int idCliente)
        {
            var cliente = new Clientes(idCliente, "cliente@cliente.com.br");
            return cliente;
        }
    }
}
