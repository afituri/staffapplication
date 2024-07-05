using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffInformationApp.Data;
using StaffInformationApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StaffInformationApp.Controllers
{
  public class ProjectController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ProjectController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Project
    public async Task<IActionResult> Index(int staffId)
    {
      var projects = await _context.Projects
          .Where(p => p.StaffId == staffId)
          .Include(p => p.Staff)
          .ToListAsync();
      ViewData["StaffId"] = staffId;
      return View(projects);
    }

    // GET: Project/Create
    public IActionResult Create(int staffId)
    {
      ViewData["StaffId"] = staffId;
      return View();
    }

    // POST: Project/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProjectTitleAndLocation,LevelOfResponsibility,BriefDescriptionOfRole,StaffId")] Project project)
    {

      _context.Add(project);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index), new { staffId = project.StaffId });

      ViewData["StaffId"] = project.StaffId;
      return View(project);
    }

    // GET: Project/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var project = await _context.Projects.FindAsync(id);
      if (project == null)
      {
        return NotFound();
      }
      ViewData["StaffId"] = project.StaffId;
      return View(project);
    }

    // POST: Project/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectTitleAndLocation,LevelOfResponsibility,BriefDescriptionOfRole,StaffId")] Project project)
    {
      if (id != project.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(project);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProjectExists(project.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index), new { staffId = project.StaffId });
      }
      ViewData["StaffId"] = project.StaffId;
      return View(project);
    }

    private bool ProjectExists(int id)
    {
      return _context.Projects.Any(e => e.Id == id);
    }
  }
}