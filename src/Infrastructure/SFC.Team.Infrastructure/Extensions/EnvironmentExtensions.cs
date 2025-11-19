using SFC.Team.Infrastructure.Constants;

namespace SFC.Team.Infrastructure.Extensions;
public static class EnvironmentExtensions
{
    public static bool IsRunningInContainer => Environment.GetEnvironmentVariable(EnvironmentConstants.RunningInContainer) == "true";
}