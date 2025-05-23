using SFC.Team.Domain.Common;

namespace SFC.Team.Domain.Entities.Request.Data;
public class RequestStatus : EnumDataEntity<RequestStatusEnum>
{
    public RequestStatus() : base() { }

    public RequestStatus(RequestStatusEnum enumType) : base(enumType) { }
}