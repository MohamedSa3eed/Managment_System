using Managment_System.DAL.Models;

namespace Managment_System.BLL.Interfaces;

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAll();

    Department? Get(int id);
    
    int Add(Department entity);
    
    int Update(Department entity);
    
    int Delete(Department entity);
}