using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BuildingCompanyWebApp.Models
{
    public partial class BuildingCompanyManagementContext : DbContext
    {
        public BuildingCompanyManagementContext()
        {
        }

        public BuildingCompanyManagementContext(DbContextOptions<BuildingCompanyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyInvestor> CompanyInvestors { get; set; }
        public virtual DbSet<CompanyPhone> CompanyPhones { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<ConstructionObject> ConstructionObjects { get; set; }
        public virtual DbSet<ConstructionObjectType> ConstructionObjectTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePhone> EmployeePhones { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<Employment> Employments { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<IndividualInvestor> IndividualInvestors { get; set; }
        public virtual DbSet<Investment> Investments { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-1HN6BBI;Initial Catalog=BuildingCompanyManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<CompanyInvestor>(entity =>
            {
                entity.ToTable("CompanyInvestor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.FoundationDatetime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyType)
                    .WithMany(p => p.CompanyInvestors)
                    .HasForeignKey(d => d.CompanyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_52");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CompanyInvestor)
                    .HasForeignKey<CompanyInvestor>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_54");
            });

            modelBuilder.Entity<CompanyPhone>(entity =>
            {
                entity.ToTable("CompanyPhone");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyInvestor)
                    .WithMany(p => p.CompanyPhones)
                    .HasForeignKey(d => d.CompanyInvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_300");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.ToTable("CompanyType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConstructionObject>(entity =>
            {
                entity.ToTable("ConstructionObject");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discription).HasColumnType("text");

                entity.HasOne(d => d.ConstructionObjectType)
                    .WithMany(p => p.ConstructionObjects)
                    .HasForeignKey(d => d.ConstructionObjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_29");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ConstructionObjects)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_32");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ConstructionObjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_28");
            });

            modelBuilder.Entity<ConstructionObjectType>(entity =>
            {
                entity.ToTable("ConstructionObjectType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_43");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_22");

                entity.HasOne(d => d.EmployeePosition)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeePositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_15");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_44");
            });

            modelBuilder.Entity<EmployeePhone>(entity =>
            {
                entity.ToTable("EmployeePhone");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePhones)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_48");
            });

            modelBuilder.Entity<EmployeePosition>(entity =>
            {
                entity.ToTable("EmployeePosition");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("EmployeeRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employment>(entity =>
            {
                entity.ToTable("Employment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_21");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_35");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_42");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IndividualInvestor>(entity =>
            {
                entity.ToTable("IndividualInvestor");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportAuthority)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PassportIssueDate).HasColumnType("datetime");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PassportfExpireDate).HasColumnType("datetime");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.IndividualInvestors)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_30");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.IndividualInvestor)
                    .HasForeignKey<IndividualInvestor>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_53");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.IndividualInvestors)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_31");
            });

            modelBuilder.Entity<Investment>(entity =>
            {
                entity.ToTable("Investment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.Investments)
                    .HasForeignKey(d => d.InvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_51");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Investments)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_39");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Investments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_49");
            });

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.ToTable("Investor");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.House)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Settlement)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Investor)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.InvestorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_37");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedEndDate).HasColumnType("datetime");

                entity.Property(e => e.PlannedStartDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProjectStatus)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_26");

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_25");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.ToTable("ProjectStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.ToTable("ProjectTask");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EndDatetime).HasColumnType("datetime");

                entity.Property(e => e.PlannedEndDatetime).HasColumnType("datetime");

                entity.Property(e => e.PlannedStartDatetime).HasColumnType("datetime");

                entity.Property(e => e.StartDatetime).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_41");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_55");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.ToTable("ProjectType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.ToTable("TaskType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
