using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Interviews2.Models;

namespace Interviews2.Controllers
{
    public class CandidatesController : Controller
    {
        private ApplicationDbContext _context;

        public CandidatesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Candidates
        public IActionResult Index()
        {
            return View(_context.Candidate.ToList());
        }

        // GET: Candidates/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Candidate candidate = _context.Candidate.Single(m => m.ID == id);
            if (candidate == null)
            {
                return HttpNotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Candidate.Add(candidate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Candidate candidate = _context.Candidate.Single(m => m.ID == id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Update(candidate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Candidate candidate = _context.Candidate.Single(m => m.ID == id);
            if (candidate == null)
            {
                return HttpNotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = _context.Candidate.Single(m => m.ID == id);
            _context.Candidate.Remove(candidate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
