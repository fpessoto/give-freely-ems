using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Employees.List;

public class ListEmployeesHandler(IListEmployeesQueryService _query)
  : IQueryHandler<ListEmployeesQuery, Result<IEnumerable<EmployeeDTO>>>
{
  public async Task<Result<IEnumerable<EmployeeDTO>>> Handle(ListEmployeesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
