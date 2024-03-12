using Ardalis.Result;
using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.EmployeeAggregate;

namespace GiveFreely.EMS.UseCases.Employees.Update;

public class UpdateEmployeeHandler(IRepository<Employee> _repository)
  : ICommandHandler<UpdateEmployeeCommand, Result<EmployeeDTO>>
{
  public async Task<Result<EmployeeDTO>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
  {
    var existingEmployee = await _repository.GetByIdAsync(request.EmployeeId, cancellationToken);
    if (existingEmployee == null)
    {
      return Result.NotFound();
    }

    if (!string.IsNullOrEmpty(request.FirstName))
      existingEmployee.UpdateFirstName(request.FirstName!);

    if (!string.IsNullOrEmpty(request.LastName))
      existingEmployee.UpdateLastName(request.LastName!);

    if (!string.IsNullOrEmpty(request.Email))
      existingEmployee.UpdateEmail(request.Email!);

    if (!string.IsNullOrEmpty(request.JobTitle))
      existingEmployee.UpdateJobTitle(request.JobTitle!);

    if (request.DateOfJoining != null)
      existingEmployee.UpdateDateOfJoining((DateTime)request.DateOfJoining);

    await _repository.UpdateAsync(existingEmployee, cancellationToken);

    return Result.Success(
      new EmployeeDTO(existingEmployee.Id,
                      existingEmployee.FirstName,
                      existingEmployee.LastName,
                      existingEmployee.Email,
                      existingEmployee.JobTitle, existingEmployee.DateOfJoining,
                      existingEmployee.TotalYearsOfService));
  }
}
