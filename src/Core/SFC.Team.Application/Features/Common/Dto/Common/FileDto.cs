using SFC.Team.Domain.Enums.Data;

namespace SFC.Team.Application.Features.Common.Dto.Common;
public class FileDto
{
    public IEnumerable<byte> Source { get; set; } = [];

    public string Name { get; set; } = string.Empty;

    public PhotoExtension Extension { get; set; }

    public int Size { get; set; }
}