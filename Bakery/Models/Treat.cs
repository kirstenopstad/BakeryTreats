using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Treat
  {
    // properties, constructors, methods, etc. go here
    public int TreatId { get; set; }
    [Required( ErrorMessage = "Treat name is required!")]
    public string Name { get; set; }
    public List<FlavorTreat> FlavorTreats { get; set; }
  }
}
