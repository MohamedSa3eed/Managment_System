using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managment_System.PL.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IHostEnvironment _hostEnvironment;

    public DepartmentController(IDepartmentRepository departmentRepository, IHostEnvironment  hostEnvironment )
    {
        _departmentRepository = departmentRepository;
        _hostEnvironment = hostEnvironment;
    }
    
    public IActionResult Index()
    {
        return View(_departmentRepository.GetAll());
    }
    
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Department department)
    {
        if (ModelState.IsValid)
        {
            var count = _departmentRepository.Add(department);
            if (count > 0)
                return RedirectToAction("Index");
        }
        return View(department);
    }

    public IActionResult Details(int? id, string viewName="Details")
    {
        if (!id.HasValue)
            return BadRequest(); //400
        
        var department = _departmentRepository.Get(id.Value);
        if (department == null)
            return NotFound(); //404
        
        return View(viewName, department);
    }
    
    public IActionResult Edit(int? id)
    {
        return Details(id, "Edit");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Department department)
    {
        if (!ModelState.IsValid)
            return View(department);
        try
        {
            _departmentRepository.Update(department);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            // log
            if (_hostEnvironment.IsDevelopment())
            {
                ModelState.AddModelError("", e.Message);
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while updating the department.");
            }
            return View(department);
        }
    }

    public IActionResult Delete(int? id)
    {
        return Details(id, "Delete");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Department department)
    {
        if (!ModelState.IsValid)
            return View(department);
        try
        {
            _departmentRepository.Delete(department);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            // log
            if (_hostEnvironment.IsDevelopment())
            {
                ModelState.AddModelError("", e.Message);
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while deleting the department.");
            }
            return View(department);
        }
    }
}