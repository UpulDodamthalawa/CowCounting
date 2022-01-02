using CowCounting.Models;
using System.Collections.Generic;

namespace CowCounting.Interfaces
{
  public interface ICowCounterService
  {
    int CountCornerCows(List<Cow> cows, int fieldSize);

    int CountAdjacentCows(List<Cow> cows, int fieldSize);
  }
}
