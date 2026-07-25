using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Data;
using Managment_System.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment_System.BLL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
{
    private protected readonly ApplicationDbContext _dbContext;
    
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; // for dependency injection 
    }
    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().AsNoTracking().ToList();
    }

    public T? Get(int id)
    {
        // var employee = _dbContext.Employees.Local.Where(e => e.Id == id).FirstOrDefault();
        // if (employee == null)
        //     employee = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
        // return employee;
        return _dbContext.Find<T>(id);
    }

    public int Add(T entity)
    {
        // _dbContext.Add(entity); // New Feature EF Core 3.1
        _dbContext.Set<T>().Add(entity);
        return _dbContext.SaveChanges();
    }

    public int Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return _dbContext.SaveChanges();
    }

    public int Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return _dbContext.SaveChanges();
    }
    
}