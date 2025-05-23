namespace SFC.Team.Messages.Models.Team.General;
public class TeamGeneralProfile
{
    public required string Name { get; set; }

    public required string City { get; set; }

    public long? LocationId { get; set; }

    public string? Description { get; set; }
}