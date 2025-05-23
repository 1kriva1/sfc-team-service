using SFC.Team.Domain.Common.Interfaces;

namespace SFC.Team.Domain.Common;
public abstract class BaseAuditableReferenceEntity<T> : BaseEntity<T>, IAuditableReferenceEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public Guid LastModifiedBy { get; set; }
}