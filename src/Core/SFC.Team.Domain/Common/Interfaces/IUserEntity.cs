using SFC.Team.Domain.Entities.Identity;

namespace SFC.Team.Domain.Common.Interfaces;
public interface IUserEntity
{
    Guid UserId { get; set; }
}