using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectName.Models
{
  public class ProjectNameContext : IdentityDbContext<ApplicationUser>
  {
    // include DbSets as needed

    // does this need to be updated as well?
    public ProjectNameContext(DbContextOptions options) : base(options) { }
  }
}