using SFC.Team.Domain.Entities.Metadata;

namespace SFC.Team.Application.Interfaces.Persistence.Context;
public interface IMetadataDbContext : IDbContext
{
    IQueryable<MetadataEntity> Metadata { get; }
}