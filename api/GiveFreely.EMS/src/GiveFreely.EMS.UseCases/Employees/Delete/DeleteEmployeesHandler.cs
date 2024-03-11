using Ardalis.Result;
using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.Interfaces;

namespace GiveFreely.EMS.UseCases.Employees.Delete;

public class DeleteEmployeeHandler(IDeleteEmployeeService _deleteEmployeeService)
  : ICommandHandler<DeleteEmployeeCommand, Result>
{
  public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is @ardalis's preferred approach
    return await _deleteEmployeeService.DeleteEmployee(request.EmployeeId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.EmployeeId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new EmployeeDeletedEvent(request.EmployeeId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
