using Managment_System.DAL.Models;

namespace Managment_System.BLL.Interfaces;

public interface IEmployeeRepository
{
    public IEnumerable<Employee> GetAll();
    public Employee? Get(int id);
    public int Add(Employee entity);
    public int Update(Employee entity);
    public int Delete(Employee entity);
}