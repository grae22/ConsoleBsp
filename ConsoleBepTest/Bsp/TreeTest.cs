using System.Collections.Generic;
using NUnit.Framework;
using ConsoleBsp;
using ConsoleBsp.Bsp;

namespace ConsoleBepTest.Bsp
{
  public class TreeTest
  {
    [Test]
    public void Constructor_GivenLines_ShouldBuildTree()
    {
      // Arrange.

      /*           (r2)
       *            |
       *    (E1)---------(E2)
       *            |
       * (B1)--(B2) | (C1)--(C2)
       *            |
       * (A1)--(A2) | (D1)--(D2)
       *           (r1)
       *    (F1)---------(F2)
       */
      var lines = new List<Line2d>
      {
        new Line2d(new Point2d(-5, -5), new Point2d(-2, -5)),   // A
        new Line2d(new Point2d(-5, -8), new Point2d(-2, -8)),   // B
        new Line2d(new Point2d(0, -8), new Point2d(2, -8)),     // C
        new Line2d(new Point2d(0, -5), new Point2d(2, -5)),     // D
        new Line2d(new Point2d(-3, -9), new Point2d(1, -9)),    // E
        new Line2d(new Point2d(-3, 1), new Point2d(1, 1))       // F
      };

      var ray = new Line2d(
        new Point2d(-1, -1),
        new Point2d(-1, -10));

      var testObject = new Tree(lines);

      // Act.
      Line2d result = testObject.FindFirstIntersectingLine(ray);

      // Assert.
      Assert.NotNull(result);
    }

    [Test]
    public void FindFirstIntersectingLine_GivenRayWithStartInFrontRootPlane_ShouldTraverseTreeUsingNodesBehind()
    {
      // Arrange.

      /*           (r1)
       *            |
       * (A1)---A2) |
       *            |
       * (B1)---------------(B2)
       *            |
       *           (r2)
       */
      var lines = new List<Line2d>
      {
        new Line2d(new Point2d(-5, 2), new Point2d(-1, 2)), // A
        new Line2d(new Point2d(-5, 5), new Point2d(5, 5))   // B
      };

      var ray = new Line2d(
        new Point2d(1, 0),    // r1
        new Point2d(1, 7));   // r2

      var testObject = new Tree(lines);

      // Act.
      Line2d result = testObject.FindFirstIntersectingLine(ray);

      // Assert.
      Assert.NotNull(result);
      Assert.AreEqual(result, lines[1]);
      Assert.Fail("WIP");
    }
  }
}
