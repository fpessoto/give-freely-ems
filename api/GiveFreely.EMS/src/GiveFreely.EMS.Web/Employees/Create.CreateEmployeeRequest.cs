using System.ComponentModel.DataAnnotations;

namespace GiveFreely.EMS.Web.Employee;

public class CreateEmployeeRequest
{
  public const string Route = "/Employees";

  [Required]
  public string? FirstName { get; set; }
  [Required]
  public string? LastName { get; set; }
  [Required]
  public string? Email { get; set; }
  [Required]
  public string? JobTitle { get; set; }
  [Required]
  public DateTime DateOfJoining { get; set; }
}
