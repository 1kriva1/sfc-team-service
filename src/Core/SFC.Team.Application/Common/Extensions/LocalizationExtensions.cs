using SFC.Team.Application.Common.Constants;
using SFC.Team.Domain.Common.Interfaces;

namespace SFC.Team.Application.Common.Extensions;
public static class LocalizationExtensions
{
    public static void Localize(this IEnumEntity value) => value.Title = Localization.GetDataValue(value.Title);

    public static IEnumerable<T> Localize<T>(this IEnumerable<T> values)
        where T : IEnumEntity
    {
        foreach (IEnumEntity value in values)
        {
            value.Localize();
        }

        return values;
    }
}