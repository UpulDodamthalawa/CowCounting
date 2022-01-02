using CowCounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CowCountingTest
{
  public class PopulateTestData
  {
    public List<Cow> Populate3AdjacentCows()
    {
      List<Cow> cows = new List<Cow>();
      var random = new Random();

      cows.Add(new Cow()
      {
        Id = 1,
        Position = new Position()
        {
          XValue = 0,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 2,
        Position = new Position()
        {
          XValue = 1,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 3,
        Position = new Position()
        {
          XValue = 2,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 4,
        Position = new Position()
        {
          XValue = 2,
          YValue = 1
        }
      });

      return cows;
    }

    public List<Cow> Populate4AdjacentCows()
    {
      List<Cow> cows = new List<Cow>();
      var random = new Random();

      cows.Add(new Cow()
      {
        Id = 1,
        Position = new Position()
        {
          XValue = 1,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 2,
        Position = new Position()
        {
          XValue = 2,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 3,
        Position = new Position()
        {
          XValue = 0,
          YValue = 1
        }
      });
      cows.Add(new Cow()
      {
        Id = 4,
        Position = new Position()
        {
          XValue = 1,
          YValue = 2
        }
      });
      cows.Add(new Cow()
      {
        Id = 5,
        Position = new Position()
        {
          XValue = 1,
          YValue = 3
        }
      });
      cows.Add(new Cow()
      {
        Id = 6,
        Position = new Position()
        {
          XValue = 2,
          YValue = 3
        }
      });

      return cows;
    }

    public List<Cow> Populate6NotAdjacentCows()
    {
      List<Cow> cows = new List<Cow>();
      var random = new Random();

      cows.Add(new Cow()
      {
        Id = 1,
        Position = new Position()
        {
          XValue = 1,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 2,
        Position = new Position()
        {
          XValue = 3,
          YValue = 0
        }
      });
      cows.Add(new Cow()
      {
        Id = 3,
        Position = new Position()
        {
          XValue = 0,
          YValue = 1
        }
      });
      cows.Add(new Cow()
      {
        Id = 4,
        Position = new Position()
        {
          XValue = 1,
          YValue = 2
        }
      });
      cows.Add(new Cow()
      {
        Id = 5,
        Position = new Position()
        {
          XValue = 0,
          YValue = 3
        }
      });
      cows.Add(new Cow()
      {
        Id = 6,
        Position = new Position()
        {
          XValue = 3,
          YValue = 3
        }
      });

      return cows;
    }

    public List<Cow> PopulateCornerCows(int fieldSize, int total, int cornerCows)
    {
      List<Cow> cows = new List<Cow>();
      var random = new Random();
      int[] cornerXPositions = { 0, 0, fieldSize - 1, fieldSize - 1 };
      int[] cornerYPositions = { 0, fieldSize - 1, 0, fieldSize - 1 };
      for (int i = 1; i <= cornerCows; i++)
      {
        var x = cornerXPositions[i - 1];
        var y = cornerYPositions[i - 1];

        cows.Add(new Cow()
        {
          Id = i,
          Position = new Position()
          {
            XValue = x,
            YValue = y
          }
        });
      }

      for (int i = 1; i <= total - cornerCows; i++)
      {
        var pos = GenerateRandomPosition(cows, fieldSize);

        cows.Add(new Cow()
        {
          Id = i,
          Position = new Position()
          {
            XValue = pos[0],
            YValue = pos[1]
          }
        });
      }

      cows = cows.OrderBy(x => x.Position.XValue).ThenBy(y => y.Position.YValue).ToList();
      int id = 1;
      foreach (var cow in cows)
      {
        cow.Id = id;
        id++;
      }
      return cows;
    }

    private int[] GenerateRandomPosition(List<Cow> cows, int fieldSize)
    {
      var random = new Random();
      var x = random.Next(0, fieldSize);
      var y = random.Next(0, fieldSize);
      do
      {
        do
        {
          x = random.Next(0, fieldSize);
          y = random.Next(0, fieldSize);
        }
        while (CornerCow(fieldSize, x, y));
      }
      while (IsCowAlreadyStayInThisPosition(cows, x, y));
      return new int[] { x, y };
    }

    private bool CornerCow(int fieldSize, int x, int y)
    {
      if (x.Equals(0) && y.Equals(0))
      {
        return true;
      }
      else if (x.Equals(0) && y.Equals(fieldSize - 1))
      {
        return true;
      }
      else if (x.Equals(fieldSize - 1) && y.Equals(0))
      {
        return true;
      }
      else if (x.Equals(fieldSize - 1) && y.Equals(fieldSize - 1))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool IsCowAlreadyStayInThisPosition(List<Cow> cows, int x, int y)
    {
      return cows.Where(c => c.Position.XValue == x && c.Position.YValue == y).Count() > 0;
    }
  }
}
