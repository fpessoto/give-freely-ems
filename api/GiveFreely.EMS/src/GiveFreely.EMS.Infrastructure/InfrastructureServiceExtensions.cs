using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.Interfaces;
using GiveFreely.EMS.Core.Services;
using GiveFreely.EMS.Infrastructure.Data;
using GiveFreely.EMS.Infrastructure.Data.Queries;
using GiveFreely.EMS.Infrastructure.Email;
using GiveFreely.EMS.UseCases.Employees.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GiveFreely.EMS.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("SqliteConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseSqlite(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

    services.AddScoped<IListEmployeesQueryService, ListEmployeesQueryService>();
    services.AddScoped<IDeleteEmployeeService, DeleteEmployeeService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
