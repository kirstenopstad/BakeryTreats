using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Flavor
  {
    // properties, constructors, methods, etc. go here
    public int FlavorId { get; set; }
    [Required( ErrorMessage = "Flavor type is required!")]
    public string Type { get; set; }
  }
}
