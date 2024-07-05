using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffInformationApp.Data;
using StaffInformationApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StaffInformationApp.Controllers
{
  public class StaffController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly ILogger<StaffController> _logger;

    public StaffController(ApplicationDbContext context, ILogger<StaffController> logger)
    {
      _context = context;
      _logger = logger;
    }

    // GET: Staff
    public async Task<IActionResult> Index()
    {
      var staffList = await _context.Staff
          .Include(s => s.HighestLevelOfEducation)
          .Include(s => s.DutyStation)
          .ToListAsync();
      return View(staffList);
    }

    // GET: Staff/Create
    public IActionResult Create()
    {
      ViewData["HighestLevelOfEducationId"] = new SelectList(_context.EducationLevels, "Id", "Level");
      ViewData["DutyStationId"] = new SelectList(_context.DutyStations, "Id", "Location");
      return View();
    }

    // POST: Staff/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IndexNumber,FullNames,Email,CurrentLocation,HighestLevelOfEducationId,DutyStationId,AvailabilityForRemoteWork")] Staff staff)
    {
      _logger.LogInformation("Entering Create method");
      _logger.LogDebug("Staff details: {@Staff}", staff);

      // if (ModelState.IsValid)
      // {
      _logger.LogInformation("Model state is valid");
      try
      {
        _context.Add(staff);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Staff member created successfully");
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while saving the staff member");
      }
      // }
      // else
      // {
      //   _logger.LogWarning("Model state is invalid");
      //   foreach (var modelStateKey in ModelState.Keys)
      //   {
      //     var value = ModelState[modelStateKey];
      //     foreach (var error in value.Errors)
      //     {
      //       _logger.LogWarning("Key: {Key}, Error: {ErrorMessage}", modelStateKey, error.ErrorMessage);
      //     }
      //   }
      // }

      ViewData["HighestLevelOfEducationId"] = new SelectList(_context.EducationLevels, "Id", "Level", staff.HighestLevelOfEducationId);
      ViewData["DutyStationId"] = new SelectList(_context.DutyStations, "Id", "Location", staff.DutyStationId);
      return View();
    }

    // Add other CRUD actions as necessary
  }
}
