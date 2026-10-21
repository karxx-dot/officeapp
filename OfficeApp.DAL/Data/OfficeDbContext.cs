using Microsoft.EntityFrameworkCore;
using OfficeApp.DAL.Models.HR;
using OfficeApp.DAL.Models.Inventory;
using OfficeApp.DAL.Models.Operations;
using OfficeApp.DAL.Models.Documents;

namespace OfficeApp.DAL.Data;

public class OfficeDbContext : DbContext
{
    public OfficeDbContext(DbContextOptions<OfficeDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<AssetAssignment> AssetAssignments => Set<AssetAssignment>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Meeting> Meetings => Set<Meeting>();
    public DbSet<MeetingAttendee> MeetingAttendees => Set<MeetingAttendee>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<Document> Documents => Set<Document>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Departments", "HR");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Positions", "HR");
            entity.Property(x => x.MinSalary).HasPrecision(18, 2);
            entity.Property(x => x.MaxSalary).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employees", "HR");
            entity.Property(x => x.Salary).HasPrecision(18, 2);
            entity.HasIndex(x => x.Email).IsUnique();
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("Attendances", "HR");
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.ToTable("LeaveRequests", "HR");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories", "Inventory");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Suppliers", "Inventory");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.ToTable("Assets", "Inventory");
            entity.Property(x => x.PurchaseCost).HasPrecision(18, 2);
            entity.HasIndex(x => x.Code).IsUnique();
        });

        modelBuilder.Entity<AssetAssignment>(entity =>
        {
            entity.ToTable("AssetAssignments", "Inventory");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Rooms", "Operations");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservations", "Operations");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.ToTable("Meetings", "Operations");
        });

        modelBuilder.Entity<MeetingAttendee>(entity =>
        {
            entity.ToTable("MeetingAttendees", "Operations");
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("TaskItems", "Operations");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.ToTable("DocumentTypes", "Documents");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Documents", "Documents");
        });

        // Evita rutas de cascada multiples en SQL Server
        foreach (var fk in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
