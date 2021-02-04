using Microsoft.EntityFrameworkCore;
using BeOn.Models;

namespace BeOn
{
    public class BeOnContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceEnvironment> Environments { get; set; }
        public DbSet<DevicePositionning> Positionnings { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public BeOnContext(DbContextOptions<BeOnContext> options)
            : base(options) { }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceEnvironment>()
                        .HasKey(environmentPayload => new { environmentPayload.DeviceId, environmentPayload.TimestampEvent, environmentPayload.SeqNumber });

            modelBuilder.Entity<DevicePositionning>()
                        .HasKey(positionningPayload => new { positionningPayload.DeviceId, positionningPayload.TimestampEvent, positionningPayload.SeqNumber });

            modelBuilder.Entity<Device>()
                        .HasMany(device => device.EnvironmentPayloads)
                        .WithOne(environmentPayload => environmentPayload.Device)
                        .HasForeignKey(environmentPayload => environmentPayload.DeviceId);

            modelBuilder.Entity<Role>()
                        .HasMany(role => role.Authorizations)
                        .WithOne(authorization => authorization.Role);

            modelBuilder.Entity<Authorization>()
                        .HasKey(authorization => new { authorization.PermissionId, authorization.RoleId });
        }
    }
}
