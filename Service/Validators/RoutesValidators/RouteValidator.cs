using Domain.Entities;
using Domain.Enum;
using FluentValidation;
using System;

namespace Service.Validators
{
    public class RouteValidator : AbstractValidator<Route>
    {

        //private readonly IRouteExistenceChecker _routeExistenceChecker;
        
        public RouteValidator()
        {

            RuleFor(x => x.Origin)
                    .NotEmpty().WithMessage("Por favor, informe a origem!")
                    .NotNull().WithMessage("Por favor, informe a origem!")
                    .Must(x => x.Length == 3).WithMessage("A origem deve ter 3 caracteres")
                    .Must(origin => Enum.TryParse<AirportCodesEnum>(origin.ToUpper(), out var code)).WithMessage("Informe uma sigla de aeroporto válida");

            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage("Por favor, informe a destino!")
                .NotNull().WithMessage("Por favor, informe a destino!")
                   .Must(x => x.Length == 3).WithMessage("O destino deve ter 3 caracteres")
                .Must((model, destination) => destination != model.Origin).WithMessage("A origem não pode ser igual ao destino")
                .Must(Destination => Enum.TryParse<AirportCodesEnum>(Destination.ToUpper(), out var code)).WithMessage("Informe uma sigla de aeroporto válida");

            RuleFor(x => x.Price)
                .NotNull().NotEmpty().WithMessage("Informe o valor da rota!")
                .Must(x => Decimal.TryParse(x.ToString(), out var result)).WithMessage("Este campo não aceita letras, apenas números/valores. Ex: 10 ou 45");

            
        } 
    }
}
