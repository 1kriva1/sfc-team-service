﻿using Microsoft.AspNetCore.Authorization;

namespace SFC.Team.Infrastructure.Authorization;
public class PolicyModel
{
    public string Name { get; set; } = default!;

    public AuthorizationPolicy Policy { get; set; } = default!;
}