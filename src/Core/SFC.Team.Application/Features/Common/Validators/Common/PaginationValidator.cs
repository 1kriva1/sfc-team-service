using FluentValidation;

using SFC.Team.Application.Features.Common.Dto.Pagination;

namespace SFC.Team.Application.Features.Common.Validators.Common;
public class PaginationValidator : AbstractValidator<PaginationDto>
{
    public PaginationValidator()
    {
        RuleFor(p => p.Page)
            .GreaterThanOrEqualTo(1)
            .WithName(nameof(PaginationDto.Page));

        RuleFor(p => p.Size)
            .GreaterThanOrEqualTo(1)
            .WithName(nameof(PaginationDto.Size));
    }
}