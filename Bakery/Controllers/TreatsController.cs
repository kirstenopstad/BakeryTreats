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
  public class TreatsController : Controller
  {
    private readonly BakeryContext _db;

    public TreatsController (BakeryContext db)
    {
      _db = db;
    }

    // Index
    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Treats.ToList());
    }
    // Create GET
    public ActionResult Create()
    {
      return View();
    }

    // Create POST
    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index"); 
      }
    }

    // Details
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      // Pass in list of flavors
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Type");
      Treat thisTreat = _db.Treats
                           .Include(treat => treat.FlavorTreats)
                           .ThenInclude(flavTreat => flavTreat.Flavor)
                           .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    
    // AddFlavor
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      # nullable enable
      FlavorTreat? assoc = _db.FlavorTreats
                              .FirstOrDefault(assoc => (assoc.TreatId == treat.TreatId && assoc.FlavorId == flavorId));
      # nullable disable
      if (assoc == null && flavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat { TreatId = treat.TreatId, FlavorId = flavorId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", "Treats", new { id = treat.TreatId});
    }

    // Edit
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    // Edit  POST
    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        _db.Treats.Update(treat);
        _db.SaveChanges();
        return RedirectToAction("Details", "Treats", new { id = treat.TreatId});
      }

    }
    
    // Delete POST
    [HttpPost]
    public ActionResult Delete(Treat treat)
    {
        _db.Treats.Remove(treat);
        _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }

}