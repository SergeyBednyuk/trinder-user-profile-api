using Microsoft.EntityFrameworkCore;
using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Infrastructure.Persistence;

public class UserProfilesDbContext(DbContextOptions<UserProfilesDbContext> options) : DbContext(options)
{
    public DbSet<Foto> Fotos{ get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<UserProfileInterest> ProfileInterests { get; set; }
    public DbSet<TrinderUserProfile> TrinderUserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TrinderUserProfile>()
            .HasMany(e => e.Interests)
            .WithMany(e => e.UserProfiles)
            .UsingEntity<UserProfileInterest>();

        modelBuilder.Entity<TrinderUserProfile>()
            .HasMany<Foto>(e => e.Fotos)
            .WithOne(e => e.UserProfile)
            .HasForeignKey(e => e.UserProfileId);

    }
}
