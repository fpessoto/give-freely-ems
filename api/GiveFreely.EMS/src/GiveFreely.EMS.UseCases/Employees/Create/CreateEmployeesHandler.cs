using Ardalis.Result;
using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.EmployeeAggregate;

namespace GiveFreely.EMS.UseCases.Employees.Create;

public class CreateEmployeeHandler(IRepository<Employee> _repository)
  : ICommandHandler<CreateEmployeeCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateEmployeeCommand request,
    CancellationToken cancellationToken)
  {
    var newEmployee = new Employee(request.FirstName, request.LastName, request.Email, request.JobTitle, request.DateOfJoining);

    var createdItem = await _repository.AddAsync(newEmployee, cancellationToken);

    return createdItem.Id;
  }
}
