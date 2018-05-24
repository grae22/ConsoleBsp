namespace ConsoleBsp
{
  internal class PointClassifier
  {
    //---------------------------------------------------------------------------------------------

    public enum Classification
    {
      InFront,
      Behind,
      Coincident
    }

    //---------------------------------------------------------------------------------------------

    public static Classification ClassifyPointToLine(in Point2d point, in Line2d line)
    {
      var s = (line.Equation.A * point.X) + (line.Equation.B * point.Y) + line.Equation.C;

      if (s > double.Epsilon)
      {
        return Classification.Behind;
      }

      if (s < -double.Epsilon)
      {
        return Classification.InFront;
      }

      return Classification.Coincident;
    }

    //---------------------------------------------------------------------------------------------
  }
}