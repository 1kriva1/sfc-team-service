using FluentValidation;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Features.Common.Validators.Common;
using SFC.Team.Application.Features.Team.General.Common.Dto;
using SFC.Team.Application.Features.Team.General.Queries.Find.Dto.Filters;

namespace SFC.Team.Application.Features.Team.General.Queries.Find;
public class GetTeamsQueryValidator : AbstractValidator<GetTeamsQuery>
{
    public GetTeamsQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetTeamsViewModel, GetTeamsFilterDto>());

        // filter
        SetRulesForGeneralProfile();
    }

    private void SetRulesForGeneralProfile()
    {
        When(p => p.Filter?.Profile?.General != null, () =>
        {
            RuleFor(p => p.Filter!.Profile!.General!.Name)
                    .MaximumLength(ValidationConstants.NameValueMaxLength)
                    .WithName(nameof(GetTeamsGeneralProfileFilterDto.Name));

            RuleFor(p => p.Filter!.Profile!.General!.City)
                    .MaximumLength(ValidationConstants.CityValueMaxLength)
                    .WithName(nameof(GetTeamsGeneralProfileFilterDto.City));
        });

        When(p => p.Filter?.Profile?.General?.Tags?.Any() ?? false, () =>
        {
            RuleFor(p => p.Filter.Profile!.General!.Tags)
                .Must(tags => tags!.Distinct().Count() == tags!.Count())
                .WithMessage(Localization.MustBeUnique)
                .Must(tags => tags!.Count() <= ValidationConstants.TagsMaxLength)
                .WithName(nameof(TeamGeneralProfileDto.Tags))
                .WithMessage(Localization.TagsSizeInvalid.BuildValidationMessage(nameof(TeamGeneralProfileDto.Tags), ValidationConstants.TagsMaxLength));

            RuleForEach(p => p.Filter.Profile!.General!.Tags)
                .NotEmpty()
                .WithName(nameof(TeamGeneralProfileDto.Tags))
                .WithMessage(Localization.TagEmpty)
                .MaximumLength(ValidationConstants.TagValueMaxLength)
                .WithMessage(Localization.TagMaxLength);
        });

        When(p => p.Filter?.Profile?.General?.Availability?.Days?.Any() ?? false, () =>
        {
            RuleFor(p => p.Filter.Profile!.General!.Availability!.Days)
                .Must(days => days.Count() <= Enum.GetNames(typeof(DayOfWeek)).Length)
                .WithMessage(Localization.MustNotExceedSize.BuildValidationMessage(nameof(GetTeamsAvailabilityLimitDto.Days), Enum.GetNames(typeof(DayOfWeek)).Length));

            RuleForEach(p => p.Filter.Profile!.General!.Availability!.Days)
                .IsInEnum()
                .WithName(nameof(GetTeamsAvailabilityLimitDto.Days))
                .WithMessage(Localization.AvailabilityDayInvalid);

        });

        When(p => (p.Filter?.Profile?.General?.Availability?.From.HasValue ?? false)
            && (p.Filter?.Profile?.General.Availability?.To.HasValue ?? false), () =>
        {
            RuleFor(p => p.Filter.Profile!.General!.Availability!.To)
                .GreaterThanOrEqualTo(p => p.Filter.Profile!.General!.Availability!.From!.Value)
                .WithMessage(Localization.MustBeGreaterThan.BuildValidationMessage(nameof(GetTeamsAvailabilityLimitDto.To), nameof(GetTeamsAvailabilityLimitDto.From)));

            RuleFor(p => p.Filter.Profile!.General!.Availability!.From)
                .LessThanOrEqualTo(p => p.Filter.Profile!.General!.Availability!.To!.Value)
                .WithMessage(Localization.MustBeLessThan.BuildValidationMessage(nameof(GetTeamsAvailabilityLimitDto.From), nameof(GetTeamsAvailabilityLimitDto.To)));
        });
    }
}