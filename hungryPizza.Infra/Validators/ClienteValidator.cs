using FluentValidation;
using hungryPizza.Core.DTOs;

namespace hungryPizza.Infra.Validators
{
    public class ClienteValidator : AbstractValidator<ClientesDTO>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("E-mail obrigatório")
                                 .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(c => c.Endereco)
                .NotNull().WithMessage("Endereço não pode ser nulo")
                .NotEmpty().WithMessage("Endereço obrigatório");

            RuleFor(c => c.Numero)
                .NotNull().WithMessage("Numero não pode ser nulo")
                .NotEmpty().WithMessage("Numero obrigatório");

            RuleFor(c => c.Cep)
                .NotNull().WithMessage("Cep não pode ser nulo")
                .NotEmpty().WithMessage("Cep obrigatório");

            RuleFor(c => c.Bairro)
                .NotNull().WithMessage("Bairro não pode ser nulo")
                .NotEmpty().WithMessage("Bairro obrigatório");

            RuleFor(c => c.Cidade)
                .NotNull().WithMessage("Cidade não pode ser nulo")
                .NotEmpty().WithMessage("Cidade obrigatório");

            RuleFor(c => c.Telefone)
                .NotNull().WithMessage("Telefone não pode ser nulo")
                .NotEmpty().WithMessage("Telefone obrigatório");
        }
    }
}
