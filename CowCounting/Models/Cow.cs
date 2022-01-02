namespace CowCounting.Models
{
  public class Cow
  {
    public Cow()
    {
      Position = new Position();
    }
    public int Id { get; set; }
    public Position Position { get; set; }
  }

  public class Position
  {
    public int XValue { get; set; }

    public int YValue { get; set; }
  }
}
