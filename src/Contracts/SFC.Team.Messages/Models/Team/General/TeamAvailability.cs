namespace SFC.Team.Messages.Models.Team.General;
public class TeamAvailability
{
    public DayOfWeek Day { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}