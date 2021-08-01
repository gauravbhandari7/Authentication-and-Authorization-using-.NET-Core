using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Controllers
{
    [Authorize] 
    public class FlightController : Controller
    {
        private readonly AppDBContext _db;
        public FlightController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if(TempData["CreateMessage"] != null)
            {
                ViewBag.Message = TempData["CreateMessage"];
            }
            if (TempData["EditMessage"] != null)
            {
                ViewBag.Message = TempData["EditMessage"];
            }
            if (TempData["DeleteMessage"] != null)
            {
                ViewBag.Message = TempData["DeleteMessage"];
            }
            IEnumerable<Flight> objlist = _db.Flight;
            return View(objlist);
        }
        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight obj)
        {
            if(ModelState.IsValid)
            {
                _db.Flight.Add(obj);
                _db.SaveChanges();
                TempData["CreateMessage"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET-Edit
        public IActionResult Edit(int id)
        {
            var obj = _db.Flight.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Flight obj)
        {
            if (ModelState.IsValid)
            {
                _db.Flight.Update(obj);
                _db.SaveChanges();
                TempData["EditMessage"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET-Delete
        public IActionResult Delete(int id)
        {
            var obj = _db.Flight.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Flight obj)
        {
            _db.Flight.Remove(obj);
            _db.SaveChanges();
            TempData["DeleteMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
