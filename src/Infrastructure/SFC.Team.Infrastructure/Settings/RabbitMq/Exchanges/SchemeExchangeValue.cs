using SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;

namespace SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges;
public class SchemeExchangeValue
{
    public DataExchange<SchemeDataDependentExchange> Data { get; set; } = default!;
}

public class SchemeDataDependentExchange
{
    public DataDependentExchange Team { get; set; } = default!;
}