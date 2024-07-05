using Microsoft.EntityFrameworkCore;

using DigitalTwin.src.Model;

namespace DigitalTwin.src
{
    public class DigitalTwinDBContext(
        DbContextOptions<DigitalTwinDBContext> options
        ) : DbContext(options)
    {
        public DbSet<LogData> LOG_DATA { get; set; }
        public DbSet<SensorDevice> SENSOR_DEVICES { get; set; }
        public DbSet<User> USERS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogData>()
                .HasKey(l => l._id);

            modelBuilder.Entity<LogData>()
                .Property(l => l._id)
                .ValueGeneratedOnAdd();
        }
    }
}
