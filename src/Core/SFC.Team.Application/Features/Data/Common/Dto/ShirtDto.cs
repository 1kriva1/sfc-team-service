using SFC.Team.Application.Common.Dto.Data;
using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Domain.Entities.Data;

namespace SFC.Team.Application.Features.Data.Common.Dto;
public class ShirtDto : DataDto, IMapTo<Shirt> { }