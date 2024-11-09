using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using Segumientos.Web.Data;

public class PasswordController : Controller
{
    private readonly TaskContext _context;

    public PasswordController(TaskContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new PasswordGenerator());
    }

    [HttpPost]
    public async Task<IActionResult> Index(PasswordGenerator model)
    {
        if (ModelState.IsValid)
        {
            model.GeneratePassword();
            _context.PasswordGenerators.Add(model);
            await _context.SaveChangesAsync();
            return View("Result", model);
        }
        return View(model);
    }

    public async Task<IActionResult> List()
    {
        List<PasswordGenerator> passwords = await _context.PasswordGenerators.ToListAsync();
        return View(passwords);
    }

    public IActionResult Result()
    {
        return View();
    }
}
