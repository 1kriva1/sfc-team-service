using SFC.Team.Domain.Common.Interfaces;

namespace SFC.Team.Domain.Common;
public class DataEntity<TId> : BaseEntity<TId>, IDataEntity
{
    public DateTime CreatedDate { get; set; }
}