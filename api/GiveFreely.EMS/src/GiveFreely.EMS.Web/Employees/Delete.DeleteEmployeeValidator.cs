using FastEndpoints;
using FluentValidation;

namespace GiveFreely.EMS.Web.Employees;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteEmployeeValidator : Validator<DeleteEmployeeRequest>
{
  public DeleteEmployeeValidator()
  {
    RuleFor(x => x.EmployeeId)
      .GreaterThan(0);
  }
}
