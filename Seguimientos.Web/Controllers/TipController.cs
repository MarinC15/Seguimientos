using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seguimientos.Web.Data.Entities;
using Segumientos.Web.Data;
using Segumientos.Web.Data.Entities;
using System;

namespace Seguimientos.Web.Controllers
{
    public class TipController : Controller
    {
        private readonly TaskContext _context;
        public TipController(TaskContext context) 
        {
            _context = context; 
        }
        [HttpGet] 
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost] 
        public async Task<IActionResult> Index(TipCalculator model) 
        {
            if (ModelState.IsValid) 
            { 
                model.CalculateTip(); 
                _context.TipCalculators.Add(model); 
                await _context.SaveChangesAsync(); 
                
                return View("Result", model); 
            } 
            
            return View(model); 
        }

        [HttpGet]
        public IActionResult Result()
        {
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<TipCalculator> tips = await _context.TipCalculators.ToListAsync();
            return View(tips);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TipCalculator? tips = await _context.TipCalculators.FindAsync(id);
            if (tips != null)
            {
                _context.TipCalculators.Remove(tips);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(List));
        }


    }
}
