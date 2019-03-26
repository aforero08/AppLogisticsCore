using AppLogistics.DataContext.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppLogistics.DataContext.Context
{
    public partial class AppLogisticsContext : IdentityDbContext<ApplicationUser>, IAppLogisticsContext
    {
        public AppLogisticsContext()
        {
        }

        public AppLogisticsContext(DbContextOptions<AppLogisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Afp> Afp { get; set; }
        public virtual DbSet<BranchOffice> BranchOffice { get; set; }
        public virtual DbSet<Carrier> Carrier { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientArea> ClientArea { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Eps> Eps { get; set; }
        public virtual DbSet<Holding> Holding { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            builder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            builder.Entity<Afp>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            

            builder.Entity<BranchOffice>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            builder.Entity<Carrier>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            builder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BranchOffice)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.BranchOfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_BranchOffice");
            });

            builder.Entity<ClientArea>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientArea)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientArea_Client");
            });

            builder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            builder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DocumentNumber)
                    .HasName("IX_UQ_UniqueEmployee")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BornDate).HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContact)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContactPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RetirementDate).HasColumnType("date");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Afp)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.AfpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_AFP");

                entity.HasOne(d => d.BranchOffice)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.BranchOfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_BranchOffice");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_DocumentType");

                entity.HasOne(d => d.Eps)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EpsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EPS");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_MaritalStatus");
            });

            builder.Entity<Eps>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            builder.Entity<Holding>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Holding)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Holding_Employee");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Holding)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Holding_Service");
            });

            builder.Entity<MaritalStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            builder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            builder.Entity<Rate>(entity =>
            {
                entity.HasIndex(e => new { e.ClientId, e.ActivityId, e.VehicleTypeId })
                    .HasName("IX_UQ_UniqueRate")
                    .IsUnique();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Rate)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_Activity");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Rate)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_Client");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Rate)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK_Rate_VehicleType");
            });

            builder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ExecutionDate).HasColumnType("datetime");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HoldingPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VehicleNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Activity");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.CarrierId)
                    .HasConstraintName("FK_Service_Carrier");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Client");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Service_Product");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("FK_Service_VehicleType");
            });

            builder.Entity<VehicleType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });
        }
    }
}
