namespace SFC.Team.Api.Infrastructure.Models.Common;

/// <summary>
/// Exclude Ids filter model
/// </summary>
public class ExcludeFilterModel
{
    /// <summary>
    /// Filter for exclude Ids from result set
    /// </summary>
    public IEnumerable<long> ExcludeIds { get; set; } = default!;
}