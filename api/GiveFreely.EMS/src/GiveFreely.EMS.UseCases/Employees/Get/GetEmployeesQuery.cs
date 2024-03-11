using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Employees.Get;

public record GetEmployeeQuery(int EmployeeId) : IQuery<Result<EmployeeDTO>>;
