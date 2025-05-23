using System.Linq.Expressions;

using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Common.Models.Sorting;
public class Sorting<T, TKey>
{
    public bool Condition { get; set; }

    public Expression<Func<T, TKey>> Expression { get; set; } = default!;

    public SortingDirection Direction { get; set; }
}