using ConsoleBsp.Extensions;

namespace ConsoleBsp
{
  internal class Line2d
  {
    //---------------------------------------------------------------------------------------------

    public struct LinearEquation
    {
      public double A { get; set; }
      public double B { get; set; }
      public double C { get; set; }
    }

    public Point2d Vertex1 { get; }
    public Point2d Vertex2 { get; }
    public LinearEquation Equation { get; private set; }

    //---------------------------------------------------------------------------------------------

    public Line2d(in Point2d vertex1, in Point2d vertex2)
    {
      Vertex1 = vertex1;
      Vertex2 = vertex2;

      Equation = default;

      CalculateEquationValues();
    }

    //---------------------------------------------------------------------------------------------

    public static bool operator ==(in Line2d l1, in Line2d l2)
    {
      return l1.Vertex1 == l2?.Vertex1 &&
             l1.Vertex2 == l2?.Vertex2;
    }

    //---------------------------------------------------------------------------------------------
    
    public static bool operator !=(in Line2d l1, in Line2d l2)
    {
      return !(l1.Vertex1 == l2?.Vertex1 &&
               l1.Vertex2 == l2?.Vertex2);
    }

    //---------------------------------------------------------------------------------------------

    public override bool Equals(object other)
    {
      if (other is Line2d otherAsLine)
      {
        return this == otherAsLine;
      }

      return base.Equals(other);
    }

    //---------------------------------------------------------------------------------------------

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    //---------------------------------------------------------------------------------------------

    public Line2d[] Split(in Line2d hyperplane)
    {
      double crossX = 0;
      double crossY = 0;
      double divider = (hyperplane.Equation.A * Equation.B) - (hyperplane.Equation.B * Equation.A);

      // Calculate cross x & y.
      if (divider.IsZero())
      {
        if (Equation.A.IsZero())
        {
          crossX = Vertex1.X;
        }

        if (Equation.B.IsZero())
        {
          crossY = Vertex1.Y;
        }

        if (hyperplane.Equation.A.IsZero())
        {
          crossY = -hyperplane.Equation.B;
        }

        if (hyperplane.Equation.B.IsZero())
        {
          crossX = hyperplane.Equation.C;
        }
      }
      else
      {
        crossX = ((-hyperplane.Equation.C * Equation.B) + (hyperplane.Equation.B * Equation.C)) / divider;
        crossY = ((-hyperplane.Equation.A * Equation.C) + (hyperplane.Equation.C * Equation.A)) / divider;
      }

      // Classify points.
      var t1 = PointClassifier.ClassifyPointToLine(Vertex1, hyperplane);
      var t2 = PointClassifier.ClassifyPointToLine(Vertex2, hyperplane);

      // Generate new lines.
      double l1v1x = Vertex1.X;
      double l1v1y = Vertex1.Y;
      double l1v2x = Vertex2.X;
      double l1v2y = Vertex2.Y;
      double l2v1x = Vertex1.X;
      double l2v1y = Vertex1.Y;
      double l2v2x = Vertex2.X;
      double l2v2y = Vertex2.Y;

      if (t1 == PointClassifier.Classification.Behind &&
          t2 == PointClassifier.Classification.InFront)
      {
        l1v1x = crossX;
        l1v1y = crossY;
        l1v2x = Vertex2.X;
        l1v2y = Vertex2.Y;
        l2v1x = Vertex1.X;
        l2v1y = Vertex1.Y;
        l2v2x = crossX;
        l2v2y = crossY;
      }
      else if (t1 == PointClassifier.Classification.InFront &&
               t2 == PointClassifier.Classification.Behind)
      {
        l1v1x = Vertex1.X;
        l1v1y = Vertex1.Y;
        l1v2x = crossX;
        l1v2y = crossY;
        l2v1x = crossX;
        l2v1y = crossY;
        l2v2x = Vertex2.X;
        l2v2y = Vertex2.Y;
      }
      else
      {
        return null;
      }

      return new[]
      {
        new Line2d(new Point2d(l1v1x, l1v1y), new Point2d(l1v2x, l1v2y)),
        new Line2d(new Point2d(l2v1x, l2v1y), new Point2d(l2v2x, l2v2y))
      };
    }

    //---------------------------------------------------------------------------------------------

    private void CalculateEquationValues()
    {
      double dx = Vertex2.X - Vertex1.X;
      double dy = Vertex2.Y - Vertex1.Y;

      Equation = new LinearEquation
      {
        A = -dy,
        B = dx,
        C = (dy * Vertex1.X) - (dx * Vertex1.Y)
      };
    }

    //---------------------------------------------------------------------------------------------
  }
}
