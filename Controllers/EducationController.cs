using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffInformationApp.Data;
using StaffInformationApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StaffInformationApp.Controllers
{
  public class EducationLevelController : Controller
  {
    private readonly ApplicationDbContext _context;

    public EducationLevelController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: EducationLevel
    public async Task<IActionResult> Index()
    {
      return View(await _context.EducationLevels.ToListAsync());
    }

    // GET: EducationLevel/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var educationLevel = await _context.EducationLevels
          .FirstOrDefaultAsync(m => m.Id == id);
      if (educationLevel == null)
      {
        return NotFound();
      }

      return View(educationLevel);
    }

    // GET: EducationLevel/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: EducationLevel/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Level")] EducationLevel educationLevel)
    {
      if (ModelState.IsValid)
      {
        _context.Add(educationLevel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(educationLevel);
    }

    // GET: EducationLevel/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var educationLevel = await _context.EducationLevels.FindAsync(id);
      if (educationLevel == null)
      {
        return NotFound();
      }
      return View(educationLevel);
    }

    // POST: EducationLevel/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Level")] EducationLevel educationLevel)
    {
      if (id != educationLevel.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(educationLevel);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!EducationLevelExists(educationLevel.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(educationLevel);
    }

    // GET: EducationLevel/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var educationLevel = await _context.EducationLevels
          .FirstOrDefaultAsync(m => m.Id == id);
      if (educationLevel == null)
      {
        return NotFound();
      }

      return View(educationLevel);
    }

    // POST: EducationLevel/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var educationLevel = await _context.EducationLevels.FindAsync(id);
      _context.EducationLevels.Remove(educationLevel);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool EducationLevelExists(int id)
    {
      return _context.EducationLevels.Any(e => e.Id == id);
    }
  }
}
