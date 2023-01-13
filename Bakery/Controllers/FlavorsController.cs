using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Bakery.Models;

namespace Bakery.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly BakeryContext _db;

    public FlavorsController (BakeryContext db)
    {
      _db = db;
    }

    // Index
    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }
    // Create GET
    public ActionResult Create()
    {
      return View();
    }

    // Create POST
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // Details
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      // Pass in list of treats
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      Flavor thisFlavor = _db.Flavors
                             .Include(flav => flav.FlavorTreats)
                             .ThenInclude(flavTreats => flavTreats.Treat)
                             .FirstOrDefault(flav => flav.FlavorId == id);
      return View(thisFlavor);
    }

    // Add Treat
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      // Check if association already exists
      # nullable enable
      FlavorTreat? assoc = _db.FlavorTreats
                              .FirstOrDefault(assoc => (assoc.FlavorId == flavor.FlavorId && assoc.TreatId == treatId));
      # nullable disable
      if (assoc == null && treatId != 0)
      {
        _db.FlavorTreats.Add( new FlavorTreat {FlavorId = flavor.FlavorId, TreatId = treatId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", "Flavors", new { id = flavor.FlavorId});
    }
    
    // Edit  POST
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      RedirectToAction("Details", "Flavors", new { id = flavor.FlavorId});
    }
    
    // Delete POST

  }
}