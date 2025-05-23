namespace SFC.Team.Messages.Models.Team.General;
public class TeamLogo
{
#pragma warning disable CA1819 // Properties should not return arrays
    public required byte[] Source { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    public required string Name { get; set; }

    public required string Extension { get; set; }

    public int Size { get; set; }
}