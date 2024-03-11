using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Employees.Update;

public record UpdateEmployeeCommand(int EmployeeId, string NewName) : ICommand<Result<EmployeeDTO>>;
