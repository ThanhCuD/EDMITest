﻿using Microsoft.EntityFrameworkCore;

namespace EDMITest.Entity
{
    public partial class EdmiContext : DbContext
    {
        public EdmiContext()
        {

        }
        public EdmiContext(DbContextOptions<EdmiContext> options)
           : base(options)
        {
        }
        public virtual DbSet<WaterMeter> WaterMeters { get; set; }
        public virtual DbSet<ElectricMeter> ElectricMeters { get; set; }
        public virtual DbSet<Gateways> Gateways { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WaterMeter>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("water_meter");
                entity.Property(e => e.ID)
                    .HasColumnName("id")
                    .UseSqlServerIdentityColumn();
                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number");
                entity.Property(e => e.FirmwareVersion)
                    .HasColumnName("firmware_version");
                entity.Property(e => e.State)
                    .HasColumnName("state");
            });
            modelBuilder.Entity<ElectricMeter>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("electric_meter");
                entity.Property(e => e.ID)
                    .HasColumnName("id")
                     .UseSqlServerIdentityColumn();
                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number");
                entity.Property(e => e.FirmwareVersion)
                    .HasColumnName("firmware_version");
                entity.Property(e => e.State)
                    .HasColumnName("state");
            });
            modelBuilder.Entity<Gateways>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("gateways");
                entity.Property(e => e.ID)
                    .HasColumnName("id")
                    .UseSqlServerIdentityColumn();
                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number");
                entity.Property(e => e.FirmwareVersion)
                    .HasColumnName("firmware_version");
                entity.Property(e => e.State)
                    .HasColumnName("state");
                entity.Property(e => e.Port)
                    .HasColumnName("port");
                entity.Property(e => e.IP)
                    .HasColumnName("ip");
            });
        }
    }
}