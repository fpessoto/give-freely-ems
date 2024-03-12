using System.ComponentModel.DataAnnotations;

namespace GiveFreely.EMS.Web.Employees;

public class UpdateEmployeeRequest
{
  public const string Route = "/Employees/{EmployeeId:int}";
  public static string BuildRoute(int EmployeeId) => Route.Replace("{EmployeeId:int}", EmployeeId.ToString());

  public int EmployeeId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public string? FirstName { get; set; }
  [Required]
  public string? LastName { get; set; }
  [Required]
  public string? Email { get; set; }
  [Required]
  public string? JobTitle { get; set; }
  [Required]
  public DateTime? DateOfJoining { get; set; }
}
