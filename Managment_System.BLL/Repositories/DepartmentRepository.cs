using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Data;
using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.BLL.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public DepartmentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; // for dependency injection 
    }
    public IEnumerable<Department> GetAll()
    {
        return _dbContext.Departments.AsNoTracking().ToList();
    }

    public Department? Get(int id)
    {
        // var department = _dbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
        // if (department == null)
        //     department = _dbContext.Departments.Where(d => d.Id == id).FirstOrDefault();
        // return department;
        return _dbContext.Find<Department>(id);
    }

    public int Add(Department entity)
    {
        _dbContext.Departments.Add(entity);
        return _dbContext.SaveChanges();
    }

    public int Update(Department entity)
    {
        _dbContext.Departments.Update(entity);
        return _dbContext.SaveChanges();
    }

    public int Delete(Department entity)
    {
        _dbContext.Departments.Remove(entity);
        return _dbContext.SaveChanges();
    }
}