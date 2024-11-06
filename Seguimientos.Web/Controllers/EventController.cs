using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seguimientos.Web.Data.Entities;
using Segumientos.Web.Data;
using System;

namespace Seguimientos.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly TaskContext _context;

        public EventController(TaskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> even = await _context.Events.ToListAsync();
            return View(even);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event even)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(even);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(even);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Event? even = await _context.Events.FindAsync(id);
            if (even == null)
            {
                return NotFound();
            }
            return View(even);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Event even)
        {
            if (ModelState.IsValid)
            {
                _context.Update(even);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(even);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Event? even = await _context.Events.FindAsync(id);
            if (even != null)
            {
                _context.Events.Remove(even);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Confirm(int id)
        {
            Event? even = await _context.Events.FindAsync(id);
            if (even != null)
            {
                even.IsReminderSet = !even.IsReminderSet;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
