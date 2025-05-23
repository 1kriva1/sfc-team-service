using SFC.Team.Application.Common.Dto.Data;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Request.Data;

namespace SFC.Team.Application.Features.Request.Data.Common.Dto;
public class RequestStatusDto : DataDto, IMapTo<RequestStatus> { }