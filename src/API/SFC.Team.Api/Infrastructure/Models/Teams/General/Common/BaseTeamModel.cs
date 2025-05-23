namespace SFC.Team.Api.Infrastructure.Models.Teams.General.Common;

/// <summary>
/// **Base** team model.
/// </summary>
public class BaseTeamModel
{
    /// <summary>
    /// Team's profile model.
    /// </summary>
    public TeamProfileModel Profile { get; set; } = null!;
}