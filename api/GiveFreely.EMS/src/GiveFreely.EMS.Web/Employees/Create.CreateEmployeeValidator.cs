using GiveFreely.EMS.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace GiveFreely.EMS.Web.Employee;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateEmployeeValidator : Validator<CreateEmployeeRequest>
{
  public CreateEmployeeValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
