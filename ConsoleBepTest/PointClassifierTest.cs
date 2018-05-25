using NUnit.Framework;
using ConsoleBsp;

namespace ConsoleBepTest
{
  [TestFixture]
  public class PointClassifierTest
  {
    //---------------------------------------------------------------------------------------------

    [Test]
    [TestCase(-10, 10, 10, 10, 0, 0)]
    [TestCase(10, 10, -10, 10, 0, 20)]
    [TestCase(0, 10, 0, 0, -5, 5)]
    [TestCase(0, 0, 0, 10, 5, 5)]
    public void ClassifyPointToLine_GivenPointInFront_ShouldReturnFront(
      double v1x, double v1y,
      double v2x, double v2y,
      double px, double py)
    {
      // Arrange.
      var vertex1 = new Point2d(v1x, v1y);
      var vertex2 = new Point2d(v2x, v2y);
      var line = new Line2d(vertex1, vertex2);
      var point = new Point2d(px, py);

      // Act.
      PointClassifier.Classification result = PointClassifier.ClassifyPointToLine(point, line);

      // Assert.
      Assert.AreEqual(PointClassifier.Classification.InFront, result);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    public void ClassifyPointToLine_GivenPointBehind_ShouldReturnBehind()
    {
      // Arrange.
      var vertex1 = new Point2d(-10, 10);
      var vertex2 = new Point2d(10, 10);
      var line = new Line2d(vertex1, vertex2);
      var point = new Point2d(0, 20);

      // Act.
      PointClassifier.Classification result = PointClassifier.ClassifyPointToLine(point, line);

      // Assert.
      Assert.AreEqual(PointClassifier.Classification.Behind, result);
    }

    //---------------------------------------------------------------------------------------------

    [Test]
    public void ClassifyPointToLine_GivenPointOnLine_ShouldReturnCoincident()
    {
      // Arrange.
      var vertex1 = new Point2d(-10, 10);
      var vertex2 = new Point2d(10, 10);
      var line = new Line2d(vertex1, vertex2);
      var point = new Point2d(0, 10);

      // Act.
      PointClassifier.Classification result = PointClassifier.ClassifyPointToLine(point, line);

      // Assert.
      Assert.AreEqual(PointClassifier.Classification.Coincident, result);
    }

    //---------------------------------------------------------------------------------------------
  }
}
