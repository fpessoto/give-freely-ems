using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Employees.Delete;

public record DeleteEmployeeCommand(int EmployeeId) : ICommand<Result>;
