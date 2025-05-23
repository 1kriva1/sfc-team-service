﻿using SFC.Team.Application.Interfaces.Persistence.Context;
using SFC.Team.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Team.Domain.Common;

namespace SFC.Team.Application.Interfaces.Persistence.Repository.Invite.Data;

/// <summary>
/// Data related repository (Data service).
/// Enum based entities.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TEnum">Enum type.</typeparam>
public interface IInviteDataRepository<TEntity, TEnum> : IDataRepository<TEntity, IInviteDbContext, TEnum>
    where TEntity : EnumDataEntity<TEnum>
    where TEnum : struct
{ }