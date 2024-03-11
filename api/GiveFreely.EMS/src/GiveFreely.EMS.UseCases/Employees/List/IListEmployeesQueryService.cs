namespace GiveFreely.EMS.UseCases.Employees.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListEmployeesQueryService
{
  Task<IEnumerable<EmployeeDTO>> ListAsync();
}
