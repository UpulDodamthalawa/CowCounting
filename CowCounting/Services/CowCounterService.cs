using CowCounting.Interfaces;
using CowCounting.Models;
using System.Collections.Generic;
using System.Linq;

namespace CowCounting.Services
{
  public class CowCounterService : ICowCounterService
  {
    public CowCounterService()
    {

    }    

    public int CountCornerCows(List<Cow> cows, int fieldSize)
    {
      int numOfCornerCows = 0;

      for (int cow=1; cow <= cows.Count() ; cow++)
      {
        int xPosition = GetCowXPositionByCowId(cows, cow);
        int yPosition = GetCowYPositionByCowId(cows, cow);
        numOfCornerCows += GetCornerCow(fieldSize, xPosition, yPosition);
      }
      return numOfCornerCows;
    }

    public int CountAdjacentCows(List<Cow> cows, int fieldSize)
    {
      int totalAdcCows = 0;
      int numOfAdcCowsInARow = 0;

      for (int x = 0; x < fieldSize; x++)
      {
        for (int y = 0; y < fieldSize; y++)
        {
          if (IsCowAlreadyStayInThisPosition(cows, x, y))
          {
            numOfAdcCowsInARow++;
            if(y==fieldSize-1 && numOfAdcCowsInARow>1)
            {
              totalAdcCows += numOfAdcCowsInARow;
              numOfAdcCowsInARow = 0;
            }
          }
          else
          {
            if(numOfAdcCowsInARow>1)
            {
              totalAdcCows += numOfAdcCowsInARow;
              numOfAdcCowsInARow = 0;
            }
            else
            {
              numOfAdcCowsInARow = 0;
            }
          }

        }
        numOfAdcCowsInARow = 0;
      }
      return totalAdcCows;
    }

    private int GetCornerCow(int fieldSize, int xVal, int yVal)
    {
      if (xVal == 0 && yVal == 0)
      {
        return 1;
      }
      else if (xVal == 0 && yVal == fieldSize -1)
      {
        return 1;
      }
      else if (xVal == fieldSize-1 && yVal == 0)
      {
        return 1;
      }
      else if (xVal == fieldSize - 1 && yVal == fieldSize-1)
      {
        return 1;
      }
      else
      {
        return 0;
      }
    }

    private bool IsCowAlreadyStayInThisPosition(List<Cow> cows, int x, int y)
    {
      return cows.Where(c => c.Position.XValue == x && c.Position.YValue == y).Count() > 0;
    }

    public int GetCowXPositionByCowId(List<Cow> cows, int id)
    {
      Cow cow = cows.Find(x => x.Id == id);
      return cow.Position.XValue;
    }

    public int GetCowYPositionByCowId(List<Cow> cows, int id)
    {
      Cow cow = cows.Find(x => x.Id == id);
      return cow.Position.YValue;
    }
  }
}
