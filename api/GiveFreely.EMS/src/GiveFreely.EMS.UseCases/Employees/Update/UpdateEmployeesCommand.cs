using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Employees.Update;

public record UpdateEmployeeCommand(int EmployeeId, string? FirstName, string? LastName, string? Email, string? JobTitle, DateTime? DateOfJoining) : ICommand<Result<EmployeeDTO>>;
