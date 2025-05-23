using SFC.Team.Application.Common.Enums;

namespace SFC.Team.Application.Features.Common.Dto.Common;
public class SortingDto
{
    public required string Name { get; set; }

    public SortingDirection Direction { get; set; }
}