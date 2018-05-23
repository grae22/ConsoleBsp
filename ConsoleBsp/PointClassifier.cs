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

    public static Classification ClassifyPointToLine(Point2d point, Line2d line)
    {
      return Classification.Behind;
    }

    //---------------------------------------------------------------------------------------------
  }
}