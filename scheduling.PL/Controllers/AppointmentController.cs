using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scheduling.BLL.Interfaces;
using Scheduling.DAL.Data;
using Scheduling.DAL.Models;
 

namespace scheduling.PL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentController(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        // GET: Appointment
        public IActionResult Index()
        {
            return View( _repo.GetAll());
        }

        // GET: Appointment/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _repo.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,StartDate,EndDate,ReminderDate,IsCompleted,IsReminderset")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(appointment);
             
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate,ReminderDate,IsCompleted,IsReminderset")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _repo.Update(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: demo/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _repo.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id != null)
            {
                _repo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: demo/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _repo.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        private bool AppointmentExists(DateTime date)
        {
            return _repo.GetReminder(date) != null;
        }
        
    }
}
