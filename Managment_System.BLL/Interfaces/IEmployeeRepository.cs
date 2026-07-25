using Managment_System.DAL.Models;

namespace Managment_System.BLL.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    IQueryable<Employee> GetEmployeesByAddress(string address);
}