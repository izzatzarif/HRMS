using Microsoft.AspNetCore.Mvc;
using HRMS.Models;
using HRMS.Data;
using System.Linq;

namespace HRMS.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Training
        public IActionResult Index()
        {
            var trainings = _context.Trainings.ToList();
            return View(trainings);
        }

        // GET: Training/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Training training)
        {
            if (ModelState.IsValid)
            {
                _context.Trainings.Add(training);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training);
        }

        // GET: Training/Edit/{id}
        public IActionResult Edit(int id)
        {
            var training = _context.Trainings.Find(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Training/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Training training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(training);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training);
        }

        // GET: Training/Delete/{id}
        public IActionResult Delete(int id)
        {
            var training = _context.Trainings.Find(id);
            if (training == null)
            {
                return NotFound();
            }
            _context.Trainings.Remove(training);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
