﻿namespace SFC.Team.Application.Interfaces.Common;
public interface IDateTimeService
{
    DateTime Now { get; }

    DateTime DateNow { get; }
}