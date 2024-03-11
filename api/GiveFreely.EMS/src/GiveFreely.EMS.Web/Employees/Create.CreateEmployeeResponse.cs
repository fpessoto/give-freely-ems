namespace GiveFreely.EMS.Web.Employee;

public class CreateEmployeeResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
