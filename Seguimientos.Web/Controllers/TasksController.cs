using Microsoft.AspNetCore.Mvc;
using Segumientos.Web.Data.Entities;
using Segumientos.Web.Data;
using Microsoft.EntityFrameworkCore;


namespace Segumientos.TaskList.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;
        public TasksController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TaskL> tasks = await _context.Tasks.ToListAsync();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskL task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            TaskL? task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TaskL? task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
