using Microsoft.EntityFrameworkCore;
using BeOn.Models;

namespace BeOn
{
    public class BeOnContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<EnvironmentPayload> EnvironmentPayloads { get; set; }
        public DbSet<PositionningPayload> PositionningPayloads { get; set; }
        public BeOnContext(DbContextOptions<BeOnContext> options)
            : base(options) { }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnvironmentPayload>()
                        .HasKey(e => new { e.DeviceId, e.TimestampEvent, e.SeqNumber });

            modelBuilder.Entity<PositionningPayload>()
                        .HasKey(e => new { e.DeviceId, e.TimestampEvent, e.SeqNumber });

            modelBuilder.Entity<Device>()
                        .HasMany(d => d.EnvironmentPayloads)
                        .WithOne(e => e.Device)
                        .HasForeignKey(e => e.DeviceId);
        }
    }
}
