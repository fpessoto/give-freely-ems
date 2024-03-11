using Ardalis.Specification;

namespace GiveFreely.EMS.Core.EmployeeAggregate.Specifications;

public class EmployeeByIdSpec : Specification<Employee>
{
  public EmployeeByIdSpec(int EmployeeId)
  {
    Query
        .Where(Employee => Employee.Id == EmployeeId);
  }
}
