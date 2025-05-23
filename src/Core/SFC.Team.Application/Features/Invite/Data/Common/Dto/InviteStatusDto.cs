using SFC.Team.Application.Common.Dto.Data;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Invite.Data;

namespace SFC.Team.Application.Features.Invite.Data.Common.Dto;
public class InviteStatusDto : DataDto, IMapTo<InviteStatus> { }