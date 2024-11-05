using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguimientos.Web.Data.Entities;
using Segumientos.Web.Data;
using System;

namespace Seguimientos.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly TaskContext _context;
        public ExpenseController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Expense> expenses = await _context.Expenses.ToListAsync();

            return View(expenses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(expense);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Expense? expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Update(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Expense? expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Summary()
        {
            var summary = _context.Expenses.GroupBy(e => new
            {
                e.Date.Year,
                e.Date.Month,
                e.Category
            }).Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                Category = g.Key.Category,
                Total = g.Sum(e => e.Amount)
            }).ToList();

            return View(summary);
        }
    }
}
