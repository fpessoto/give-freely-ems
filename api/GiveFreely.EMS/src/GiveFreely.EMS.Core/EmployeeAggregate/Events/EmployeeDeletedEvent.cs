using Ardalis.SharedKernel;

namespace GiveFreely.EMS.Core.EmployeeAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a Employee is deleted.
/// The DeleteEmployeeService is used to dispatch this event.
/// </summary>
internal sealed class EmployeeDeletedEvent(int EmployeeId) : DomainEventBase
{
  public int EmployeeId { get; init; } = EmployeeId;
}
