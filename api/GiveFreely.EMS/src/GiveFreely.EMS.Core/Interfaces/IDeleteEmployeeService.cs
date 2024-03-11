using Ardalis.Result;

namespace GiveFreely.EMS.Core.Interfaces;

public interface IDeleteEmployeeService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> DeleteEmployee(int EmployeeId);
}
