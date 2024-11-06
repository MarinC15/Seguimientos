using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguimientos.Web.Data.Entities;
using Segumientos.Web.Data;
using System;

namespace Seguimientos.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly TaskContext _context;
        public NoteController(TaskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Note> notes = await _context.Notes.ToListAsync();

            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(note);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Note? note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Update(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(note);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Note? note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ViewBag.Message = "Por favor ingrese un término de búsqueda.";

                return View("Index", await _context.Notes.ToListAsync());
            }

            List<Note> notes = await _context.Notes.Where(n =>
            n.Title.Contains(query) || n.Content.Contains(query) || n.Category.Contains(query)).ToListAsync();

            if (notes.Count == 0)
            {
                ViewBag.Message = "No se encontraron notas.";
            }

            return View("Index", notes);
        }
    }
}
