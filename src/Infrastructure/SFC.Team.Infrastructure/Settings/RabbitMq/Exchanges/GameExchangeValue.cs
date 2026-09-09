using SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;

namespace SFC.Team.Infrastructure.Settings.RabbitMq.Exchanges;
public class GameExchangeValue
{
    public DataExchange<GameDataDependentExchange> Data { get; set; } = default!;
}

public class GameDataDependentExchange
{
    public DataDependentExchange Team { get; set; } = default!;
}