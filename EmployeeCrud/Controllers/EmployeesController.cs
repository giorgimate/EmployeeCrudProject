using EmployeeCrud.Data;
using EmployeeCrud.Models;
using EmployeeCrud.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmloyeeCrudDbContext _db;
        public EmployeesController(EmloyeeCrudDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           var employees = _db.employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var emloyee = new Employee()
            {
                Name = addEmployeeRequest.Name,
                DayOfBirth = addEmployeeRequest.DayOfBirth,
                Sallary = addEmployeeRequest.Sallary,
                Department = addEmployeeRequest.Department,
                Email = addEmployeeRequest.Email
            };
            _db.employees.Add(emloyee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult View(int id)
        {
            var employee = _db.employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Sallary = employee.Sallary,
                    DayOfBirth = employee.DayOfBirth,
                    Department = employee.Department
                };
                return View("View", viewModel);
            }
            return   RedirectToAction("Index");  
        }
        [HttpPost]
        public IActionResult View(UpdateEmployeeViewModel model)
        {
            var employee = _db.employees.Find(model.Id);
            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Sallary = model.Sallary;
                employee.Email = model.Email;
                employee.DayOfBirth = model.DayOfBirth;
                employee.Department = model.Department;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(UpdateEmployeeViewModel model)
        {
            var employee = _db.employees.Find(model.Id);
            if (employee != null)
            {
                _db.employees.Remove(employee);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
