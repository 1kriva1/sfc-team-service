using FluentValidation;

using SFC.Team.Application.Features.Common.Base;
using SFC.Team.Application.Features.Common.Models.Find.Paging;

namespace SFC.Team.Application.Features.Common.Validators.Common;
public class PaginationRequestValidator<TResponse, TFilter> : AbstractValidator<BasePaginationRequest<TResponse, TFilter>>
{
    public PaginationRequestValidator()
    {
        // pagination
        RuleFor(command => command.Pagination)
            .NotNull()
            .SetValidator(new PaginationValidator())
            .WithName(nameof(Pagination));

        //sorting
        RuleForEach(command => command.Sorting)
            .SetValidator(new SortingValidator());
    }
}