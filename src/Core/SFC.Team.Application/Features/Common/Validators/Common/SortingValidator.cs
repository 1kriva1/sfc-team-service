using FluentValidation;

using SFC.Team.Application.Features.Common.Dto.Common;

namespace SFC.Team.Application.Features.Common.Validators.Common;
public class SortingValidator : AbstractValidator<SortingDto>
{
    public SortingValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithName(nameof(SortingDto.Name));

        RuleFor(p => p.Direction)
            .IsInEnum()
            .WithName(nameof(SortingDto.Direction));
    }
}