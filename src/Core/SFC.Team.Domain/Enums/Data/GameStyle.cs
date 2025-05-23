﻿using System.ComponentModel;

namespace SFC.Team.Domain.Enums.Data;
public enum GameStyle
{
    Defend = 0,
    Attacking = 1,
    Aggressive = 2,
    [Description("Counter Attacks")]
    CounterAttacks = 3
}