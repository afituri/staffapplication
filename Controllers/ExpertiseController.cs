using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffInformationApp.Data;
using StaffInformationApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StaffInformationApp.Controllers
{
  public class ExpertiseController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ExpertiseController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Expertise
    public async Task<IActionResult> Index(int staffId)
    {
      var staffExpertises = await _context.StaffSoftwareExpertise
          .Where(e => e.StaffId == staffId)
          .Include(e => e.SoftwareExpertise)
          .ToListAsync();

      ViewData["StaffId"] = staffId;
      return View(staffExpertises);
    }

    // GET: Expertise/Create
    public async Task<IActionResult> Create(int staffId)
    {
      ViewData["StaffId"] = staffId;
      ViewData["SoftwareExpertiseId"] = new SelectList(await _context.SoftwareExpertise.ToListAsync(), "Id", "SoftwareName");
      return View();
    }

    // POST: Expertise/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SoftwareExpertiseId,ExpertiseLevel,StaffId")] StaffSoftwareExpertise staffSoftwareExpertise)
    {

      _context.Add(staffSoftwareExpertise);
      await _context.SaveChangesAsync();
      return RedirectToAction("Details", "Staff", new { id = staffSoftwareExpertise.StaffId });

      ViewData["StaffId"] = staffSoftwareExpertise.StaffId;
      ViewData["SoftwareExpertiseId"] = new SelectList(_context.SoftwareExpertise, "Id", "SoftwareName", staffSoftwareExpertise.SoftwareExpertiseId);
      return View(staffSoftwareExpertise);
    }

    // GET: Expertise/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var staffSoftwareExpertise = await _context.StaffSoftwareExpertise.FindAsync(id);
      if (staffSoftwareExpertise == null)
      {
        return NotFound();
      }
      ViewData["StaffId"] = staffSoftwareExpertise.StaffId;
      ViewData["SoftwareExpertiseId"] = new SelectList(_context.SoftwareExpertise, "Id", "SoftwareName", staffSoftwareExpertise.SoftwareExpertiseId);
      return View(staffSoftwareExpertise);
    }

    // POST: Expertise/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,SoftwareExpertiseId,ExpertiseLevel,StaffId")] StaffSoftwareExpertise staffSoftwareExpertise)
    {
      if (id != staffSoftwareExpertise.Id)
      {
        return NotFound();
      }


      try
      {
        _context.Update(staffSoftwareExpertise);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StaffSoftwareExpertiseExists(staffSoftwareExpertise.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("Details", "Staff", new { id = staffSoftwareExpertise.StaffId });

      ViewData["StaffId"] = staffSoftwareExpertise.StaffId;
      ViewData["SoftwareExpertiseId"] = new SelectList(_context.SoftwareExpertise, "Id", "SoftwareName", staffSoftwareExpertise.SoftwareExpertiseId);
      return View(staffSoftwareExpertise);
    }

    private bool StaffSoftwareExpertiseExists(int id)
    {
      return _context.StaffSoftwareExpertise.Any(e => e.Id == id);
    }
  }
}
