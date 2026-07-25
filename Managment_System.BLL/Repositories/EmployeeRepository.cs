using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Data;
using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.BLL.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public IQueryable<Employee> GetEmployeesByAddress(string  address)
    {
        return _dbContext.Employees.Where(e => e.Address.ToLower() == address.ToLower()).AsNoTracking();
    }
}