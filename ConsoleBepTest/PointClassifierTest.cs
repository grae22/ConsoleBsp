using NUnit.Framework;
using ConsoleBsp;

namespace ConsoleBepTest
{
  [TestFixture]
  public class PointClassifierTest
  {
    //---------------------------------------------------------------------------------------------

    [Test]
    public void ClassifyPointToLine_GivenPointInFront_ShouldReturnFront()
    {
      // Arrange.
      var vertex1 = new Point2d(-10, 10);
      var vertex2 = new Point2d(10, 10);
      var line = new Line2d(vertex1, vertex2);
      var point = new Point2d(0, 0);

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
