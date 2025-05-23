using FluentValidation;

using SFC.Team.Application.Features.Team.General.Commands.Common.Validators;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;

namespace SFC.Team.Application.Features.Team.General.Commands.Create;
public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
{
    public CreateTeamCommandValidator(IShirtRepository shirtsRepository)
    {
        RuleFor(command => command.Team).SetValidator(new TeamValidator<CreateTeamDto>(shirtsRepository));
    }
}