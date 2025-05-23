﻿using Microsoft.EntityFrameworkCore;

using SFC.Team.Application.Interfaces.Persistence.Repository.Data;
using SFC.Team.Domain.Entities.Data;
using SFC.Team.Infrastructure.Persistence.Contexts;

namespace SFC.Team.Infrastructure.Persistence.Repositories.Data;

public class StatTypeRepository(DataDbContext context)
    : DataRepository<StatType, StatTypeEnum>(context), IStatTypeRepository
{
    public virtual Task<int> CountAsync() => Context.StatTypes.CountAsync();

    public override async Task<IReadOnlyList<StatType>> ListAllAsync()
    {
        return await Context.StatTypes
                            .AsNoTracking()
                            .ToListAsync()
                            .ConfigureAwait(false);
    }
}