using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Identity;
using SFC.Team.Domain.Entities.Team.Data;
using SFC.Team.Domain.Entities.Team.Player;
using SFC.Team.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.Player;
public class TeamPlayerConfiguration : AuditableEntityConfiguration<TeamPlayer, long>
{
    public override void Configure(EntityTypeBuilder<TeamPlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // it's for skip exception during update db (sql server only related)
        builder.HasOne<TeamEntity>()
               .WithMany()
               .HasForeignKey(e => e.TeamId)
               .OnDelete(DeleteBehavior.ClientCascade);

        //builder.HasOne(e => e.Player)
        //       .WithMany(e => e.Teams)
        //       .HasForeignKey(e => e.PlayerId);

        builder.HasOne<TeamPlayerStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Players");

        base.Configure(builder);
    }
}