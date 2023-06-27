using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ride.Models;

public partial class RideyourentContext : DbContext
{
    public RideyourentContext()
    {
    }

    public RideyourentContext(DbContextOptions<RideyourentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarBodyType> CarBodyTypes { get; set; }

    public virtual DbSet<CarMake> CarMakes { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Inspector> Inspectors { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Return1> Return1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build(); 
        optionsBuilder.UseSqlServer("Server=lab000000\\SQLEXPRESS;Database=rideyourent;Trusted_Connection=True;TrustServerCertificate=True");
        
        }
        }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarNo).HasName("PK__car__68A00DDD7482EB89");

            entity.ToTable("car");

            entity.Property(e => e.CarNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AvailabLe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AvailabLE");
            entity.Property(e => e.CarBodyTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CarBodyType_id");
            entity.Property(e => e.CarMakeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("car_make_id");
            entity.Property(e => e.Kmtravelled)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KMTravelled");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceKm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ServiceKM");

            entity.HasOne(d => d.CarBodyType).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarBodyTypeId)
                .HasConstraintName("FK__car__CarBodyType__4E88ABD4");

            entity.HasOne(d => d.CarMake).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarMakeId)
                .HasConstraintName("FK__car__car_make_id__4D94879B");
        });

        modelBuilder.Entity<CarBodyType>(entity =>
        {
            entity.HasKey(e => e.CarBodyTypeId).HasName("PK__CarBodyT__F9C443083C9164D3");

            entity.ToTable("CarBodyType");

            entity.Property(e => e.CarBodyTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CarBodyType_id");
            entity.Property(e => e.TypeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CarMake>(entity =>
        {
            entity.HasKey(e => e.CarMakeId).HasName("PK__CarMake__E038CD6AD0C6FF3C");

            entity.ToTable("CarMake");

            entity.Property(e => e.CarMakeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("car_make_id");
            entity.Property(e => e.CarDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__driver__F1B1CD24FE44B5F2");

            entity.ToTable("driver");

            entity.Property(e => e.DriverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DriverID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DriverEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DriverMobile)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inspector>(entity =>
        {
            entity.HasKey(e => e.InspectorNo).HasName("PK__Inspecto__F49FBEAFF4886078");

            entity.ToTable("Inspector");

            entity.Property(e => e.InspectorNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inspector_no");
            entity.Property(e => e.InspectorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InspectorMoblie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InspectorName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalNo).HasName("PK__rental__0164A584DF5F8710");

            entity.ToTable("rental");

            entity.Property(e => e.RentalNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rentalNo");
            entity.Property(e => e.CarNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DriverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DriverID");
            entity.Property(e => e.EndDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InspectorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RentalFee)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CarNoNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CarNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental__CarNo__5535A963");

            entity.HasOne(d => d.Driver).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental__DriverID__5629CD9C");
        });

        modelBuilder.Entity<Return1>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__return1__EBA763F9B99B913E");

            entity.ToTable("return1");

            entity.Property(e => e.ReturnId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("returnID");
            entity.Property(e => e.CarNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DriverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DriverID");
            entity.Property(e => e.ElapsedDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InspectorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnDate)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CarNoNavigation).WithMany(p => p.Return1s)
                .HasForeignKey(d => d.CarNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__return1__CarNo__59FA5E80");

            entity.HasOne(d => d.Driver).WithMany(p => p.Return1s)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__return1__DriverI__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
