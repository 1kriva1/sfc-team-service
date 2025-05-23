using SFC.Team.Domain.Common;
using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Domain.Events.Identity;
public class UsersCreatedEvent(IEnumerable<User> users) : BaseEvent
{
    public IEnumerable<User> Users { get; } = users;
}