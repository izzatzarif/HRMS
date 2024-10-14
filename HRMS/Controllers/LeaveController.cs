using Microsoft.AspNetCore.Mvc;
using HRMS.Data;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leaves = _context.Leaves.ToList();
            return View(leaves);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Leave leave)
        {
            if (ModelState.IsValid)
            {
                _context.Leaves.Add(leave);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leave);
        }

        public IActionResult Edit(int id)
        {
            var leave = _context.Leaves.Find(id);
            if (leave == null)
            {
                return NotFound();
            }
            return View(leave);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Leave leave)
        {
            if (ModelState.IsValid)
            {
                _context.Update(leave);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leave);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var leave = _context.Leaves.Find(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
