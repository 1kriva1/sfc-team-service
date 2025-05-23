using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Invite.Data;
public class InviteStatus : EnumDataEntity<InviteStatusEnum>
{
    public InviteStatus() : base() { }

    public InviteStatus(InviteStatusEnum enumType) : base(enumType) { }
}