namespace Managment_System.DAL.Models;

public class Department
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required DateTime StartDate { get; set; }
}