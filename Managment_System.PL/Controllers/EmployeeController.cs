using Managment_System.BLL.Interfaces;
using Managment_System.DAL.Data;
using Managment_System.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Managment_System.PL.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAll();
        return View(employees);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            var count = _employeeRepository.Add(employee);
            if (count > 0)
                return RedirectToAction("Index");
        }
        return View(employee);
    }
    
    public IActionResult Details(int? id, string viewName = "Details")
    {
        if (!id.HasValue)
            return BadRequest(); //400
        
        var employee = _employeeRepository.Get(id.Value);
        if (employee == null)
            return NotFound(); //404
        
        return View(viewName, employee);
    }

    public IActionResult Edit(int? id, string viewName = "Edit")
    {
        return Details(id, viewName);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        if (ModelState.IsValid)
        {
            var count = _employeeRepository.Update(employee);
            if (count > 0)
                return RedirectToAction("Index");
        }
        return View(employee);
    }

    public IActionResult Delete(int? id, string viewName = "Delete")
    {
        return Details(id, viewName);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var employee = _employeeRepository.Get(id);
        if (employee == null)
            return NotFound();
        
        var count = _employeeRepository.Delete(employee);
        if (count > 0)
            return RedirectToAction("Index");
        
        return View(employee);
    }
}