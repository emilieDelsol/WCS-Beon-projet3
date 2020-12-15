using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeOn.Models
{
    public class BeOnContext : DbContext
    {
       /* public DbSet<Device> devices { get; set; }*/
        public DbSet<EnvironmentPayload> environmentPayloads { get; set; }
        public DbSet<PositionningPayload> positionningPayloads { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

    }
}
