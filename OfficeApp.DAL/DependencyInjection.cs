using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeApp.DAL.Data;
using OfficeApp.DAL.Repositories.HR;
using OfficeApp.DAL.Repositories.Inventory;
using OfficeApp.DAL.Repositories.Operations;
using OfficeApp.DAL.Repositories.Documents;

namespace OfficeApp.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OfficeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("OfficeDb")));

        // HR
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        // Inventory
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IAssetAssignmentRepository, AssetAssignmentRepository>();

        // Operations
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IMeetingRepository, MeetingRepository>();
        services.AddScoped<IMeetingAttendeeRepository, MeetingAttendeeRepository>();
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();

        // Documents
        services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        return services;
    }
}
