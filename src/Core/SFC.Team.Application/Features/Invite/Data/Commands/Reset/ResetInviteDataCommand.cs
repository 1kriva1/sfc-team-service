using SFC.Team.Application.Common.Enums;
using SFC.Team.Application.Features.Invite.Data.Common.Dto;

namespace SFC.Team.Application.Features.Invite.Data.Commands.Reset;
public class ResetInviteDataCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.ResetInviteData; }

    public IEnumerable<InviteStatusDto> InviteStatuses { get; init; } = [];
}