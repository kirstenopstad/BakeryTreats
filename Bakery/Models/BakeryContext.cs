using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bakery.Models
{
  public class BakeryContext : IdentityDbContext<ApplicationUser>
  {
    // include DbSets as needed

    // does this need to be updated as well?
    public BakeryContext(DbContextOptions options) : base(options) { }
  }
}