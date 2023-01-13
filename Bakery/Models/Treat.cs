using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Treat
  {
    // properties, constructors, methods, etc. go here
    public int TreatId { get; set; }
    [Required( ErrorMessage = "Treat name is required!")]
    public string Name { get; set; }
  }
}
