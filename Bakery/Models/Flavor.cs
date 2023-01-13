using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Flavor
  {
    // properties, constructors, methods, etc. go here
    public int FlavorId { get; set; }
    [Required( ErrorMessage = "Flavor type is required!")]
    public string Type { get; set; }
    public List<FlavorTreat> FlavorTreats { get; set; }
  }
}
