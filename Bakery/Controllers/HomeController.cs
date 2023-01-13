using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Bakery.Models;

namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly BakeryContext _db;

    public HomeController (BakeryContext db)
    {
      _db = db;
    }

    // Routes
    // Index
    public ActionResult Index()
    {
      Treat[] treatArr = _db.Treats
                                 .Include(treat => treat.FlavorTreats)
                                 .ThenInclude(flavTreat => flavTreat.Flavor)
                                 .ToArray();
      Flavor[] flavArr = _db.Flavors
                                 .Include(flav => flav.FlavorTreats)
                                 .ThenInclude(flavTreat => flavTreat.Treat)
                                 .ToArray();
      Dictionary<string,object[]> model = new Dictionary<string,object[]>();
      model.Add("treats", treatArr);
      model.Add("flavors", flavArr);
      return View(model);
    }
    // [HttpGet(")]
    // [HttpPost("")]

  }
}