using Microsoft.EntityFrameworkCore;

using DigitalTwin.src.Model;

namespace DigitalTwin.src
{
    public class DigitalTwinDBContext(
        DbContextOptions<DigitalTwinDBContext> options
        ) : DbContext(options)
    {
        public DbSet<SensorDevice> SENSOR_DEVICES { get; set; }
        public DbSet<Temperature> TEMPERATURES { get; set; }
        public DbSet<RPM> RPMS { get; set; }
        public DbSet<Fuel> FUELS {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temperature>()
                .HasOne(t => t.SensorDevice)
                .WithMany(s => s.Temperatures)
                .HasForeignKey(t => t.SensorDeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RPM>()
                .HasOne(r => r.SensorDevice)
                .WithMany(s => s.RPMs)
                .HasForeignKey(r => r.SensorDeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fuel>()
                .HasOne(f => f.SensorDevice)
                .WithMany(s => s.Fuels)
                .HasForeignKey(f => f.SensorDeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SensorDevice>()
                .Property(s => s.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<Temperature>()
                .Property(t => t.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<RPM>()
                .Property(d => d.DeletedAt)
                .HasDefaultValue(null);

            modelBuilder.Entity<Fuel>()
                .Property(f => f.DeletedAt)
                .HasDefaultValue(null);
        }
    }
}
