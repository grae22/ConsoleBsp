using System.Collections.Generic;
using NUnit.Framework;
using ConsoleBsp;
using ConsoleBsp.Bsp;

namespace ConsoleBepTest.Bsp
{
  public class TreeTest
  {
    //---------------------------------------------------------------------------------------------

    [Test]
    public void Constructor_GivenLines_ShouldBuildTree()
    {
      // Arrange.
      var lines = new List<Line2d>
      {
        new Line2d(new Point2d(0, 0), new Point2d(0, 10)),
        new Line2d(new Point2d(-5, 5), new Point2d(5, 5))
      };

      // Act.
      new Tree(lines);

      // Assert.
    }

    //---------------------------------------------------------------------------------------------
  }
}
