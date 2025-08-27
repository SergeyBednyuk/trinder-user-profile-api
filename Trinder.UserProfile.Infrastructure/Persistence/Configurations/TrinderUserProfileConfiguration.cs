using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Infrastructure.Persistence.Configurations;

public class TrinderUserProfileConfiguration : IEntityTypeConfiguration<TrinderUserProfile>
{
    public void Configure(EntityTypeBuilder<TrinderUserProfile> builder)
    {
        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.HasMany(e => e.Interests)
            .WithMany(e => e.UserProfiles)
            .UsingEntity<UserProfileInterest>();

        builder.HasMany<Foto>(e => e.Fotos)
            .WithOne(e => e.UserProfile)
            .HasForeignKey(e => e.UserProfileId);
    }
}
