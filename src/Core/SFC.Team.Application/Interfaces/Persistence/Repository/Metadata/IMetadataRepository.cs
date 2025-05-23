using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common;
using SFC.Team.Domain.Entities.Metadata;
using SFC.Team.Domain.Enums.Metadata;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Metadata;
public interface IMetadataRepository : IRepository<MetadataEntity, IMetadataDbContext, int>
{
    Task<MetadataEntity?> GetByIdAsync(MetadataServiceEnum service, MetadataDomainEnum domain, MetadataTypeEnum type);
}