using GiveFreely.EMS.UseCases.Employees;
using GiveFreely.EMS.UseCases.Employees.List;
using Microsoft.EntityFrameworkCore;

namespace GiveFreely.EMS.Infrastructure.Data.Queries;

public class ListEmployeesQueryService(AppDbContext _db) : IListEmployeesQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<EmployeeDTO>> ListAsync()
  {
    var result = await _db.Employees
      .Select(e => new EmployeeDTO(e.Id, e.FirstName, e.LastName, e.Email, e.JobTitle, e.DateOfJoining, e.TotalYearsOfService))
      .ToListAsync();

    return result;
  }
}
