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
  public string? Name { get; set; }
}
