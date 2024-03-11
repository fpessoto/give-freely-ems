using System.ComponentModel.DataAnnotations;

namespace GiveFreely.EMS.Web.Employee;

public class CreateEmployeeRequest
{
  public const string Route = "/Employees";

  [Required]
  public string? Name { get; set; }
  public string? PhoneNumber { get; set; }
}
