using Microsoft.AspNetCore.Mvc;
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
      return View();
    }
    // [HttpGet(")]
    // [HttpPost("")]

  }
}