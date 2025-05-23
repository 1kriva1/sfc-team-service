using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Common.Constants;
using SFC.Team.Infrastructure.Authorization.OwnPlayer;
using SFC.Team.Infrastructure.Authorization.OwnTeam;
using SFC.Team.Infrastructure.Constants;

namespace SFC.Team.Infrastructure.Authorization;
public static class AuthorizationPolicies
{
    #region Public

    public static PolicyModel General(IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(claims);

        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims);
        return BuildPolicyModel(Policy.General, builder);
    }

    public static PolicyModel OwnTeam(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnTeamRequirement());

        return BuildPolicyModel(Policy.OwnTeam, builder);
    }

    public static PolicyModel OwnPlayer(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnPlayerRequirement());

        return BuildPolicyModel(Policy.OwnPlayer, builder);
    }

    #endregion Public

    #region Private

    private static AuthorizationPolicyBuilder GetGeneralPolicyBuilder(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser();

        foreach (KeyValuePair<string, IEnumerable<string>> claim in claims)
        {
            builder.RequireClaim(claim.Key, claim.Value);
        }

        return builder;
    }

    private static PolicyModel BuildPolicyModel(string name, AuthorizationPolicyBuilder builder)
    {
        return new PolicyModel { Name = name, Policy = builder.Build() };
    }

    #endregion Private
}