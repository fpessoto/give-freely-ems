using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Employees.List;

public record ListEmployeesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<EmployeeDTO>>>;
