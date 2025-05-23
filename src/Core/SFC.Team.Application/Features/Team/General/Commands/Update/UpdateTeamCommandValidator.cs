using FluentValidation;

using SFC.Team.Application.Features.Team.General.Commands.Common.Validators;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;

namespace SFC.Team.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator(IShirtRepository shirtsRepository)
    {
        RuleFor(command => command.Team).SetValidator(new TeamValidator<UpdateTeamDto>(shirtsRepository));
    }
}