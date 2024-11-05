using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguimientos.Web.Data.Entities;
using Segumientos.Web.Data;
using System;
using System.Threading.Tasks;

namespace Seguimientos.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly TaskContext _context; 
        public ReservationController(TaskContext context) 
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            List<Reservation> reservations = await _context.Reservations.ToListAsync(); 
            return View(reservations); 
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation) 
        {
            if (ModelState.IsValid)
            {
                _context.Reservations.Add(reservation); 
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); 
            }
            
            return View(reservation);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            Reservation? reservation = await _context.Reservations.FindAsync(id); 
            if (reservation == null)
            {
                return NotFound();
            }
            
            return View(reservation);
        }

        [HttpPost] 
        public async Task<IActionResult> Edit(Reservation reservation) 
        {
            if (ModelState.IsValid) 
            {
                _context.Update(reservation); 
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); 
            }
            
            return View(reservation); 
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            Reservation? reservation = await _context.Reservations.FindAsync(id); 
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index)); 
        }

        [HttpGet]
        public async Task<IActionResult> Confirm(int id) 
        {
            Reservation? reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null) 
            {
                reservation.IsConfirmed = !reservation.IsConfirmed;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index)); 
        }
    }
}
