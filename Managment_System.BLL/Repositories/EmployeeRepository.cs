using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Data;
using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.BLL.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; // for dependency injection 
    }
    public IEnumerable<Employee> GetAll()
    {
        return _dbContext.Employees.AsNoTracking().ToList();
    }

    public Employee? Get(int id)
    {
        // var employee = _dbContext.Employees.Local.Where(e => e.Id == id).FirstOrDefault();
        // if (employee == null)
        //     employee = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        // return employee;
        return _dbContext.Find<Employee>(id);
    }

    public int Add(Employee entity)
    {
        _dbContext.Employees.Add(entity);
        return _dbContext.SaveChanges();
    }

    public int Update(Employee entity)
    {
        _dbContext.Employees.Update(entity);
        return _dbContext.SaveChanges();
    }

    public int Delete(Employee entity)
    {
        _dbContext.Employees.Remove(entity);
        return _dbContext.SaveChanges();
    }
}