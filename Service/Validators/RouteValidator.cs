using Domain.Entities;
using Domain.Enum;
using FluentValidation;
using System;

namespace Service.Validators
{
    public class RouteValidator : AbstractValidator<Route>
    {
        public RouteValidator()
        {
            RuleFor(x => x.Origin)
                .NotEmpty().WithMessage("Por favor, informe a origem!")
                .NotNull().WithMessage("Por favor, informe a origem!")
                .When(x => x.Origin.Length != 3).WithMessage("A origem deve ter 3 caracteres")
                .Must(origin => Enum.TryParse<AirportCodesEnum>(origin.ToUpper(), out var code)).WithMessage("Informe uma sigla de aeroporto válida");

            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage("Por favor, informe a destino!")
                .NotNull().WithMessage("Por favor, informe a destino!")
                .When(x => x.Destination.Length != 3).WithMessage("O destino deve ter 3 caracteres")
                .Must(Destination => Enum.TryParse<AirportCodesEnum>(Destination.ToUpper(), out var code)).WithMessage("Informe uma sigla de aeroporto válida");

            RuleFor(x => x.Value)
                .NotNull().NotEmpty().WithMessage("Informe o valor da rota!")
                .Must(x => !Decimal.TryParse(x.ToString(), out var result)).WithMessage("Este campo não aceita letras, apenas números/valores. Ex: 10 ou 45");
        }
    }
}
