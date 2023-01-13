namespace Bakery.Models
{
  public class FlavorTreat
  {
    // properties, constructors, methods, etc. go here
    public int FlavorTreatId { get; set; }
    public int FlavorId { get; set; }
    public Flavor Flavor { get; set; }
    public int TreatId { get; set; }
    public Treat Treat { get; set; }
  }
}
