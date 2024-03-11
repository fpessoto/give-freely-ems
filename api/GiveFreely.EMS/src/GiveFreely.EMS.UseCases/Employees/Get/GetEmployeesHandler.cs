using Ardalis.Result;
using Ardalis.SharedKernel;
using GiveFreely.EMS.Core.EmployeeAggregate;
using GiveFreely.EMS.Core.EmployeeAggregate.Specifications;

namespace GiveFreely.EMS.UseCases.Employees.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetEmployeeHandler(IReadRepository<Employee> _repository)
  : IQueryHandler<GetEmployeeQuery, Result<EmployeeDTO>>
{
  public async Task<Result<EmployeeDTO>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
  {
    var spec = new EmployeeByIdSpec(request.EmployeeId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new EmployeeDTO(entity.Id, entity.Name, entity.PhoneNumber?.Number ?? "");
  }
}
