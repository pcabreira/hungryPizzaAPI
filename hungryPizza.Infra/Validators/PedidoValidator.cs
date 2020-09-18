using FluentValidation;
using hungryPizza.Core.DTOs;

namespace hungryPizza.Infra.Validators
{
    public class PedidoValidator : AbstractValidator<PedidosDTO>
    {
        public PedidoValidator()
        {
            RuleFor(x => x.PedidoDetalhe)
                .Must(x => x.Count > 0)
                .WithMessage("Pedido mínimo de 1 pizza");

            RuleFor(x => x.PedidoDetalhe)
                .Must(x => x.Count <= 10)
                .WithMessage("Pedido máximo de 10 pizzas");

            RuleFor(x => x.IdCliente)
                .NotEqual(0)
                .WithMessage("Id do cliente não pode ser zero");

            RuleForEach(x => x.PedidoDetalhe).ChildRules(nomePizza1 => {
                nomePizza1.RuleFor(x => x.NomePizza1)
                .NotEmpty().WithMessage("Nome da Pizza é obrigatório")
                .NotNull().WithMessage("Nome da Pizza é obrigatório");
            });

            RuleForEach(x => x.PedidoDetalhe).ChildRules(valorPizza1 => {
                valorPizza1.RuleFor(x => x.ValorPizza1)
                .NotEmpty().WithMessage("Valor da Pizza é obrigatório")
                .NotNull().WithMessage("Valor da Pizza é obrigatório");
            });
        }
    }
}
