using System.Security.Cryptography;

using SFC.Team.Domain.Common.Interfaces;

namespace SFC.Team.Domain.Common;
public abstract class BaseAuditableEntity<TId> : BaseEntity<TId>, IAuditableEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public Guid LastModifiedBy { get; set; }
}