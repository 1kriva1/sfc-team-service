using SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges;
public class RequestExchangeValue
{
    public DataExchange<RequestDataDependentExchange> Data { get; set; } = default!;

    public RequestDomainExchange Domain { get; set; } = default!;
}

public class RequestDataDependentExchange
{
    public DataDependentExchange Team { get; set; } = default!;
}

public class RequestDomainExchange
{
    public RequestTeamDomainExchange Team { get; set; } = default!;
}

public class RequestTeamDomainExchange
{
    public DomainExchange<RequestTeamPlayerDomainEventsExchange> Player { get; set; } = default!;
}

public class RequestTeamPlayerDomainEventsExchange
{
    public Exchange Updated { get; set; } = default!;
}