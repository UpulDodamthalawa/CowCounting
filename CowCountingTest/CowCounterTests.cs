using CowCounting.Interfaces;
using CowCounting.Services;
using NUnit.Framework;

namespace CowCountingTest
{
  public class Tests
  {
    private static ICowCounterService cowCounterService;

    [SetUp]
    public void SetUp()
    {
      cowCounterService = new CowCounterService();
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void CornerCows_FieldSize3_Should_ReturnCorrectNumber(int value)
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.PopulateCornerCows(3, 5, value);
      var result = cowCounterService.CountCornerCows(cornerCows, 3);
      Assert.AreEqual(result, value);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void CornerCows_FieldSize_4_Should_ReturnCorrectNumber(int value)
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.PopulateCornerCows(4, 12, value);
      var result = cowCounterService.CountCornerCows(cornerCows, 4);
      Assert.AreEqual(result, value);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void CornerCows_FieldSize_5_Should_ReturnCorrectNumber(int value)
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.PopulateCornerCows(5, 16, value);
      var result = cowCounterService.CountCornerCows(cornerCows, 5);
      Assert.AreEqual(result, value);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void CornerCows_FieldSize_10_Should_ReturnCorrectNumber(int value)
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.PopulateCornerCows(10, 60, value);
      var result = cowCounterService.CountCornerCows(cornerCows, 10);
      Assert.AreEqual(result, value);
    }

    [Test]
    public void AdjacentCows_FieldSize_5_NoAdjacentCows_Should_Return_0()
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.Populate6NotAdjacentCows();
      var result = cowCounterService.CountAdjacentCows(cornerCows, 5);
      Assert.AreEqual(result, 0);
    }

    [Test]
    public void AdjacentCows_FieldSize_3_OneGroupOfThree_Should_Return_3()
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.Populate3AdjacentCows();
      var result = cowCounterService.CountAdjacentCows(cornerCows, 3);
      Assert.AreEqual(result, 2);
    }

    [Test]
    public void AdjacentCows_FieldSize_4_TwoGroupsOfTwo_Should_Return_4()
    {
      PopulateTestData testData = new PopulateTestData();
      var cornerCows = testData.Populate4AdjacentCows();
      var result = cowCounterService.CountAdjacentCows(cornerCows, 4);
      Assert.AreEqual(result, 2);
    }
  }
}