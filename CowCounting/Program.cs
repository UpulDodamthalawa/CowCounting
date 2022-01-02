using CowCounting.Interfaces;
using CowCounting.Models;
using CowCounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CowCounting
{
  class Program
  {
    public static int totalCows = 0;
    private static List<Cow> cows;

    static void Main(string[] args)
    {
      Console.WriteLine("--------Welcome to Cow Counting App!---------");
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("Enter field size..");
      int fieldSize = int.Parse(Console.ReadLine());
      Console.WriteLine("Enter number of cows in the field..");
      int numOfCows = int.Parse(Console.ReadLine());

      cows = PopulateData(fieldSize, numOfCows);
      PrintCowPositions(fieldSize);

      ICowCounterService cowCounterService = new CowCounterService();
      int numOfCornerCows = cowCounterService.CountCornerCows(cows, fieldSize);
      Console.WriteLine($"Number of Corner Cows is {numOfCornerCows}");
      Console.WriteLine("");
      int adjCowas = cowCounterService.CountAdjacentCows(cows,fieldSize);
      Console.WriteLine($"Number of Adjacent Cows is {adjCowas}");
      Console.WriteLine("");
      Console.ReadLine();
    }

    private static List<Cow> PopulateData(int fieldSize, int numOfCows)
    {
      cows = new List<Cow>();
      var random = new Random();
      for (int i = 1; i <= numOfCows; i++)
      {
        var x = random.Next(0, fieldSize);
        var y = random.Next(0, fieldSize);
        var pos = GenerateRandomPosition(fieldSize);
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
      return cows;
    }

    private static int[] GenerateRandomPosition(int fieldSize)
    {
      var random = new Random();
      var x = random.Next(0, fieldSize);
      var y = random.Next(0, fieldSize);
      do
      {
        x = random.Next(0, fieldSize);
        y = random.Next(0, fieldSize);
      }
      while (IsCowAlreadyStayInThisPosition(x, y));
      return new int[] { x, y };
    }

    private static void PrintCowPositions(int fieldSize)
    {
      int id = 1;
      //print cow with the position values
      /*foreach (var cow in cows)
      {
        cow.Id = id;
        Console.WriteLine($"Cow id {cow.Id} - ({cow.Position.XValue},{cow.Position.YValue})");
        id++;
      }*/

      Console.WriteLine("");
      Console.WriteLine("-------------------------------------");
      Console.WriteLine("'O' represent Cow is in the position");
      Console.WriteLine("-------------------------------------");
      for (int x = 0; x < fieldSize; x++)
      {
        for (int y = 0; y < fieldSize; y++)
        {
          if (IsCowAlreadyStayInThisPosition(x, y))
          {
            Console.Write($"O ");
          }
          else
          {
            Console.Write($"X ");
          }

        }

        Console.WriteLine("");
        Console.WriteLine("");
      }
      Console.WriteLine("-------------------------------------");
    }

    private static bool IsCowAlreadyStayInThisPosition(int x, int y)
    {
      return cows.Where(c => c.Position.XValue == x && c.Position.YValue == y).Count() > 0;
    }
  }
}
