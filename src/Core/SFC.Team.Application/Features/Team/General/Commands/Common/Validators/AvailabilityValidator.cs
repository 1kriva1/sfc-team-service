using FluentValidation;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Features.Team.General.Common.Dto;

namespace SFC.Team.Application.Features.Team.General.Commands.Common.Validators;
public class AvailabilityValidator : AbstractValidator<TeamAvailabilityDto>
{
    public AvailabilityValidator()
    {
        RuleFor(p => p.Day)
                .IsInEnum()
                .WithName(nameof(TeamAvailabilityDto.Day))
                .WithMessage(Localization.AvailabilityDayInvalid);

        RuleFor(p => p.To)
                .GreaterThan(p => p.From)
                .WithMessage(Localization.MustBeGreaterThan.BuildValidationMessage(nameof(TeamAvailabilityDto.To), nameof(TeamAvailabilityDto.From)));

        RuleFor(p => p.From)
                .LessThan(p => p.To)
                .WithMessage(Localization.MustBeLessThan.BuildValidationMessage(nameof(TeamAvailabilityDto.From), nameof(TeamAvailabilityDto.To)));
    }
}