using NUnit.Framework;
using ConsoleBsp;

namespace ConsoleBepTest
{
  [TestFixture]
  public class Point2dTest
  {
    //---------------------------------------------------------------------------------------------

    [Test]
    public void Equals_GivenPointsWithSameCoords_ShouldReturnTrue()
    {
      // Arrange.
      var p1 = new Point2d(10, 20);
      var p2 = new Point2d(10, 20);

      // Act & Assert.
      Assert.True(p1.Equals(p2));
      Assert.True(p1 == p2);
      Assert.False(p1 != p2);
      Assert.AreEqual(p1, p2);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    public void Equals_GivenPointsWithDifferentCoords_ShouldReturnFalse()
    {
      // Arrange.
      var p1 = new Point2d(10, 20);
      var p2 = new Point2d(1, 2);

      // Act & Assert.
      Assert.False(p1.Equals(p2));
      Assert.False(p1 == p2);
      Assert.True(p1 != p2);
      Assert.AreNotEqual(p1, p2);
    }

    //---------------------------------------------------------------------------------------------
  }
}
