using Microsoft.AspNetCore.Mvc;
using HRMS.Models;
using HRMS.Data;

namespace HRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tindakan untuk memaparkan borang tambah pekerja (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Tindakan untuk memproses borang tambah pekerja (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Tindakan untuk memaparkan senarai pekerja
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // Tindakan untuk memaparkan borang edit pekerja (GET)
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Tindakan untuk memproses borang edit pekerja (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Tindakan untuk memproses pemadaman pekerja (DELETE)
        [HttpDelete]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return Ok(); // Menghantar respons OK jika pemadaman berjaya
            }
            return NotFound(); // Menghantar respons Not Found jika pekerja tidak wujud
        }
    }
}
