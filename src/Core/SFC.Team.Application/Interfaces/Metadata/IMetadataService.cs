using SFC.Team.Domain.Enums.Metadata;

namespace SFC.Team.Application.Interfaces.Metadata;
public interface IMetadataService
{
    Task CompleteAsync(MetadataService service, MetadataDomainEnum domain, MetadataType type);

    Task<bool> IsCompletedAsync(MetadataServiceEnum service, MetadataDomainEnum domain, MetadataTypeEnum type);
}