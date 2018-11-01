using NUnit.Framework;
using ConsoleBsp;

namespace ConsoleBepTest
{
  [TestFixture]
  public class LineClassifierTest
  {
    //---------------------------------------------------------------------------------------------

    [Test]
    [TestCase(0, -10, 10, -10, 0, 0, 5, 0)]
    [TestCase(0, 10, 10, 10, 5, 0, 0, 0)]
    [TestCase(10, 0, 10, 10, 0, 0, 0, 10)]
    [TestCase(-10, 0, -10, 10, 0, 10, 0, 0)]
    [TestCase(5, -10, 5, 0, 0, 0, 10, 0)]     // Line1 with 1 vertex on Line2.
    [TestCase(5, 0, 5, -10, 0, 0, 10, 0)]     // Line1 with 1 vertex on Line2.
    public void ClassifyLineToLine_GivenLineInFront_ShouldReturnFront(
      double line1v1x, double line1v1y,
      double line1v2x, double line1v2y,
      double line2v1x, double line2v1y,
      double line2v2x, double line2v2y)
    {
      // Arrange.
      var line1vertex1 = new Point2d(line1v1x, line1v1y);
      var line1vertex2 = new Point2d(line1v2x, line1v2y);
      var line2vertex1 = new Point2d(line2v1x, line2v1y);
      var line2vertex2 = new Point2d(line2v2x, line2v2y);

      var line1 = new Line2d(line1vertex1, line1vertex2);
      var line2 = new Line2d(line2vertex1, line2vertex2);

      // Act.
      LineClassifier.Classification result = LineClassifier.ClassifyLineToLine(line1, line2);

      // Assert.
      Assert.AreEqual(LineClassifier.Classification.InFront, result);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    [TestCase(0, 10, 10, 10, 0, 0, 5, 0)]
    [TestCase(0, -10, 10, -10, 5, 0, 0, 0)]
    [TestCase(-10, 0, -10, 10, 0, 0, 0, 10)]
    [TestCase(10, 0, 10, 10, 0, 10, 0, 0)]
    [TestCase(5, 10, 5, 0, 0, 0, 10, 0)]     // Line1 with 1 vertex on Line2.
    [TestCase(5, 0, 5, 10, 0, 0, 10, 0)]     // Line1 with 1 vertex on Line2.
    public void ClassifyLineToLine_GivenLineBehind_ShouldReturnBehind(
      double line1v1x, double line1v1y,
      double line1v2x, double line1v2y,
      double line2v1x, double line2v1y,
      double line2v2x, double line2v2y)
    {
      // Arrange.
      var line1vertex1 = new Point2d(line1v1x, line1v1y);
      var line1vertex2 = new Point2d(line1v2x, line1v2y);
      var line2vertex1 = new Point2d(line2v1x, line2v1y);
      var line2vertex2 = new Point2d(line2v2x, line2v2y);

      var line1 = new Line2d(line1vertex1, line1vertex2);
      var line2 = new Line2d(line2vertex1, line2vertex2);

      // Act.
      LineClassifier.Classification result = LineClassifier.ClassifyLineToLine(line1, line2);

      // Assert.
      Assert.AreEqual(LineClassifier.Classification.Behind, result);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    [TestCase(0, 10, 0, -10, -10, 0, 10, 0)]
    [TestCase(0, -10, 0, 10, -10, 0, 10, 0)]
    [TestCase(-10, 0, 10, 0, 0, -10, 0, 10)]
    [TestCase(10, 0, -10, 0, 0, -10, 0, 10)]
    public void ClassifyLineToLine_GivenLine1SpanningLine2_ShouldReturnIntersecting(
      double line1v1x, double line1v1y,
      double line1v2x, double line1v2y,
      double line2v1x, double line2v1y,
      double line2v2x, double line2v2y)
    {
      // Arrange.
      var line1vertex1 = new Point2d(line1v1x, line1v1y);
      var line1vertex2 = new Point2d(line1v2x, line1v2y);
      var line2vertex1 = new Point2d(line2v1x, line2v1y);
      var line2vertex2 = new Point2d(line2v2x, line2v2y);

      var line1 = new Line2d(line1vertex1, line1vertex2);
      var line2 = new Line2d(line2vertex1, line2vertex2);

      // Act.
      LineClassifier.Classification result = LineClassifier.ClassifyLineToLine(line1, line2);

      // Assert.
      Assert.AreEqual(LineClassifier.Classification.Intersecting, result);
    }

    //---------------------------------------------------------------------------------------------
    
    [Test]
    [TestCase(0, 10, 0, -10, -10, 0, -1, 0)]
    //[TestCase(0, -10, 0, 10, -10, 0, 10, 0)]
    //[TestCase(-10, 0, 10, 0, 0, -10, 0, 10)]
    //[TestCase(10, 0, -10, 0, 0, -10, 0, 10)]
    public void ClassifyLineToLine_GivenLine1SpanningLine2_ShouldReturnSpanning(
      double line1v1x, double line1v1y,
      double line1v2x, double line1v2y,
      double line2v1x, double line2v1y,
      double line2v2x, double line2v2y)
    {
      // Arrange.
      var line1vertex1 = new Point2d(line1v1x, line1v1y);
      var line1vertex2 = new Point2d(line1v2x, line1v2y);
      var line2vertex1 = new Point2d(line2v1x, line2v1y);
      var line2vertex2 = new Point2d(line2v2x, line2v2y);

      var line1 = new Line2d(line1vertex1, line1vertex2);
      var line2 = new Line2d(line2vertex1, line2vertex2);

      // Act.
      LineClassifier.Classification result = LineClassifier.ClassifyLineToLine(line1, line2);

      // Assert.
      Assert.AreEqual(LineClassifier.Classification.Spanning, result);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    [TestCase(0, 0, 0, 10, 0, 2, 0, 8)]
    [TestCase(0, 0, 0, 10, 0, 12, 0, -2)]
    [TestCase(0, 0, 10, 0, 2, 0, 8, 0)]
    [TestCase(0, 0, 10, 0, 12, 0, -2, 0)]
    public void ClassifyLineToLine_GivenCoincidentLines_ShouldReturnCoincident(
      double line1v1x, double line1v1y,
      double line1v2x, double line1v2y,
      double line2v1x, double line2v1y,
      double line2v2x, double line2v2y)
    {
      // Arrange.
      var line1vertex1 = new Point2d(line1v1x, line1v1y);
      var line1vertex2 = new Point2d(line1v2x, line1v2y);
      var line2vertex1 = new Point2d(line2v1x, line2v1y);
      var line2vertex2 = new Point2d(line2v2x, line2v2y);

      var line1 = new Line2d(line1vertex1, line1vertex2);
      var line2 = new Line2d(line2vertex1, line2vertex2);

      // Act.
      LineClassifier.Classification result = LineClassifier.ClassifyLineToLine(line1, line2);

      // Assert.
      Assert.AreEqual(LineClassifier.Classification.Coincident, result);
    }

    //---------------------------------------------------------------------------------------------
  }
}
