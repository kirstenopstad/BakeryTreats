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
    // [AllowAnonymous]
    
    // Edit  POST
    
    // Delete POST

  }
}