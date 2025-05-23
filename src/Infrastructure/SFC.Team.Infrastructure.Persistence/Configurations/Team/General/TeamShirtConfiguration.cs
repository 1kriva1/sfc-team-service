using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Team.Domain.Entities.Data;
using SFC.Team.Domain.Entities.Team.General;

namespace SFC.Team.Infrastructure.Persistence.Configurations.Team.General;
public class TeamShirtConfiguration : IEntityTypeConfiguration<TeamShirt>
{
    public void Configure(EntityTypeBuilder<TeamShirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<Shirt>()
               .WithMany()
               .HasForeignKey(t => t.ShirtId)
               .IsRequired(true);

        builder.ToTable("Shirts");
    }
}