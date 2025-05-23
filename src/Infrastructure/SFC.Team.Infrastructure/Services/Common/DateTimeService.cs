using SFC.Team.Application.Interfaces.Common;

namespace SFC.Team.Infrastructure.Services.Common;
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime DateNow => DateTime.UtcNow.Date;
}