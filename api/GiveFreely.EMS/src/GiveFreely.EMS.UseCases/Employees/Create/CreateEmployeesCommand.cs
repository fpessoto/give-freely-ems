using Ardalis.Result;

namespace GiveFreely.EMS.UseCases.Employees.Create;

/// <summary>
/// Create a new Employee.
/// </summary>
/// <param name="Name"></param>
public record CreateEmployeeCommand(string Name, string? PhoneNumber) : Ardalis.SharedKernel.ICommand<Result<int>>;
