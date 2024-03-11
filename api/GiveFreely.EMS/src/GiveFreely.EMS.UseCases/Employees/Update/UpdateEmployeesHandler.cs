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

    existingEmployee.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingEmployee, cancellationToken);

    return Result.Success(new EmployeeDTO(existingEmployee.Id,
      existingEmployee.Name, existingEmployee.PhoneNumber?.Number ?? ""));
  }
}
