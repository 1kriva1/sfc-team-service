using SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges;
public class InviteExchangeValue
{
    public DataExchange<InviteDataDependentExchange> Data { get; set; } = default!;

    public InviteDomainExchange Domain { get; set; } = default!;
}

public class InviteDataDependentExchange
{
    public DataDependentExchange Team { get; set; } = default!;
}

public class InviteDomainExchange
{
    public InviteTeamDomainExchange Team { get; set; } = default!;
}

public class InviteTeamDomainExchange
{
    public DomainExchange<InviteTeamPlayerDomainEventsExchange> Player { get; set; } = default!;
}

public class InviteTeamPlayerDomainEventsExchange
{
    public Exchange Updated { get; set; } = default!;
}