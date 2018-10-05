using NUnit.Framework;
using ConsoleBsp;

namespace ConsoleBepTest
{
  [TestFixture]
  public class Line2dTest
  {
    //---------------------------------------------------------------------------------------------

    [Test]
    public void Split_GivenIntersectingLine_ShouldReturnTwoNewLines()
    {
      // Arrange.
      var v1 = new Point2d(-10, 100);
      var v2 = new Point2d(10, 100);
      var testObject = new Line2d(v1, v2);

      v1 = new Point2d(0, -110);
      v2 = new Point2d(0, 110);
      var intersectingLine = new Line2d(v1, v2);

      v1 = new Point2d(-10, 100);
      v2 = new Point2d(0, 100);
      var expectedNewLine1 = new Line2d(v1, v2);

      v1 = new Point2d(0, 100);
      v2 = new Point2d(10, 100);
      var expectedNewLine2 = new Line2d(v1, v2);

      // Act.
      Line2d[] result = testObject.Split(intersectingLine);

      // Assert.
      Assert.AreEqual(2, result.Length);

      Assert.AreNotEqual(result[0], result[1]);

      bool result1IsExpected1 = (result[0] == expectedNewLine1);
      bool result1IsExpected2 = (result[0] == expectedNewLine2);
      bool result2IsExpected1 = (result[1] == expectedNewLine1);
      bool result2IsExpected2 = (result[1] == expectedNewLine2);

      Assert.True(result1IsExpected1 ^ result1IsExpected2);
      Assert.True(result2IsExpected1 ^ result2IsExpected2);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    public void Split_GivenNonIntersectingLine_ShouldReturnNull()
    {
      // Arrange.
      var v1 = new Point2d(-10, 0);
      var v2 = new Point2d(10, 0);
      var testObject = new Line2d(v1, v2);

      v1 = new Point2d(-10, 10);
      v2 = new Point2d(10, 10);
      var nonIntersectingLine = new Line2d(v1, v2);

      // Act.
      Line2d[] result = testObject.Split(nonIntersectingLine);

      // Assert.
      Assert.Null(result);
    }

    //---------------------------------------------------------------------------------------------
  }
}
