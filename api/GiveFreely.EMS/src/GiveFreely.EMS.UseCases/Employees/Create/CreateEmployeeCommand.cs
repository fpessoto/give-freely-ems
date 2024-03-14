using Ardalis.Result;

namespace GiveFreely.EMS.UseCases.Employees.Create;

/// <summary>
/// Create a new Employee.
/// </summary>
/// <param name="Name"></param>
public record CreateEmployeeCommand(string FirstName,
                      string LastName,
                      string Email,
                      string JobTitle,
                      DateTime DateOfJoining) : Ardalis.SharedKernel.ICommand<Result<int>>;
