using Ardalis.Result;
using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.EmployeeAggregate;
using GiveFreely.EMS.Core.EmployeeAggregate.Events;
using GiveFreely.EMS.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GiveFreely.EMS.Core.Services;

/// <summary>
/// This is here mainly so there's an example of a domain service
/// and also to demonstrate how to fire domain events from a service.
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class DeleteEmployeeService(IRepository<Employee> _repository,
  IMediator _mediator,
  ILogger<DeleteEmployeeService> _logger) : IDeleteEmployeeService
{
  public async Task<Result> DeleteEmployee(int EmployeeId)
  {
    _logger.LogInformation("Deleting Employee {EmployeeId}", EmployeeId);
    Employee? aggregateToDelete = await _repository.GetByIdAsync(EmployeeId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new EmployeeDeletedEvent(EmployeeId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
