using FluentValidation;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Application.Common.Extensions;
using SFC.Team.Application.Features.Team.General.Common.Dto;
using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;

namespace SFC.Team.Application.Features.Team.General.Commands.Common.Validators;
public class TeamValidator<T> : AbstractValidator<T> where T : BaseTeamDto
{
    private readonly IShirtRepository _shirtsRepository;

    public TeamValidator(IShirtRepository shirtsRepository)
    {
        _shirtsRepository = shirtsRepository;

        SetRulesForGeneralProfile();

        SetRulesForInventaryProfile();
    }

    private void SetRulesForGeneralProfile()
    {
        RuleFor(p => p.Profile.General.Name)
           .RequiredProperty(ValidationConstants.NameValueMaxLength, nameof(TeamGeneralProfileDto.Name));

        RuleFor(p => p.Profile.General.City)
           .RequiredProperty(ValidationConstants.CityValueMaxLength, nameof(TeamGeneralProfileDto.City));

        RuleFor(p => p.Profile.General.Description)
           .MaximumLength(ValidationConstants.DescriptionValueMaxLength)
           .WithName(nameof(TeamGeneralProfileDto.Description));

        When(p => p.Profile.General.Logo != null, () =>
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            RuleFor(p => p.Profile.General.Logo.Size)
                .InclusiveBetween(1, ValidationConstants.FileMaxSizeInBytes)
                .WithName(nameof(TeamGeneralProfileDto.Logo));

            RuleFor(p => p.Profile.General.Logo.Extension)
                .IsInEnum()
                .WithName(nameof(TeamGeneralProfileDto.Logo));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        });

        When(p => p.Profile.General.Tags?.Any() ?? false, () =>
        {
            RuleFor(p => p.Profile.General.Tags)
                .Must(tags => tags.Distinct().Count() == tags.Count())
                .WithMessage(Localization.MustBeUnique)
                .Must(tags => tags.Count() <= ValidationConstants.TagsMaxLength)
                .WithName(nameof(TeamGeneralProfileDto.Tags))
                .WithMessage(Localization.TagsSizeInvalid.BuildValidationMessage(nameof(TeamGeneralProfileDto.Tags), ValidationConstants.TagsMaxLength));

            RuleForEach(p => p.Profile.General.Tags)
                .NotEmpty()
                .WithName(nameof(TeamGeneralProfileDto.Tags))
                .WithMessage(Localization.TagEmpty)
                .MaximumLength(ValidationConstants.TagValueMaxLength)
                .WithMessage(Localization.TagMaxLength);
        });

        When(p => p.Profile.General.Availability?.Any() ?? false, () =>
        {
            RuleFor(p => p.Profile.General.Availability)
                .Must(availabilities => availabilities.DistinctBy(a => new { a.Day, a.From, a.To }).Count() == availabilities.Count())
                .WithName(nameof(TeamGeneralProfileDto.Availability))
                .WithMessage(Localization.AvailabilityUniqueness);

            RuleForEach(p => p.Profile.General.Availability)
                .SetValidator(new AvailabilityValidator());
        });
    }

    private void SetRulesForInventaryProfile()
    {
        When(p => p.Profile.Inventary.Shirts?.Any() ?? false, () =>
        {
            RuleFor(p => p.Profile.Inventary.Shirts)
                .Must(shirts => shirts.Distinct().Count() == shirts.Count())
                .WithName(nameof(TeamInventaryProfileDto.Shirts))
                .WithMessage(Localization.MustBeUnique)
                .MustAsync((shirts, cancellation) => ValidateShirtsValue(shirts))
                .WithName(nameof(TeamInventaryProfileDto.Shirts))
                .WithMessage(Localization.MustBeInDataRange);
        });
    }

    private async Task<bool> ValidateShirtsValue(IEnumerable<int> shirts)
    {
        IReadOnlyList<Shirt> dataShirts = await _shirtsRepository.ListAllAsync().ConfigureAwait(true);
        return shirts.All(shirt => dataShirts.Any(data => (int)data.Id == shirt));
    }
}