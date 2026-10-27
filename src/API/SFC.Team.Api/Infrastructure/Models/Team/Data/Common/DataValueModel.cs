using SFC.Team.Application.Common.Mappings.Interfaces;
using SFC.Team.Application.Features.Team.Data.Queries.Common.Dto;

namespace SFC.Team.Api.Infrastructure.Models.Team.Data.Common;

/// <summary>
/// Data value.
/// </summary>
public class DataValueModel : IMapFrom<DataValueDto>
{
    /// <summary>
    /// Unique identificator of data type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of data type.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Describe data type.
    /// </summary>
    public required string Title { get; set; }
}