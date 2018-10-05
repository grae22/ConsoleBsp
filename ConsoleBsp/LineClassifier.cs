namespace ConsoleBsp
{
  internal class LineClassifier
  {
    //---------------------------------------------------------------------------------------------

    public enum Classification
    {
      InFront,
      Behind,
      Spanning,     // Not "intersecting"! Spanning the plane defined by the line.
      Coincident
    }

    //---------------------------------------------------------------------------------------------

    public static Classification ClassifyLineToLine(in Line2d line1, in Line2d line2)
    {
      var v1Classification = PointClassifier.ClassifyPointToLine(line1.Vertex1, line2);
      var v2Classification = PointClassifier.ClassifyPointToLine(line1.Vertex2, line2);

      // Line1 with one vertex on Line2?
      if (v1Classification == PointClassifier.Classification.Coincident ^
          v2Classification == PointClassifier.Classification.Coincident)
      {
        if (v1Classification == PointClassifier.Classification.InFront ||
            v2Classification == PointClassifier.Classification.InFront)
        {
          return Classification.InFront;
        }

        if (v1Classification == PointClassifier.Classification.Behind ||
            v2Classification == PointClassifier.Classification.Behind)
        {
          return Classification.Behind;
        }
      }

      // In-front, behind or spanning.
      bool v1IsInFrontOrBehind =
        v1Classification == PointClassifier.Classification.InFront ||
        v1Classification == PointClassifier.Classification.Behind;

      bool v2IsInFrontOrBehind =
        v2Classification == PointClassifier.Classification.InFront ||
        v2Classification == PointClassifier.Classification.Behind;

      if (v1IsInFrontOrBehind && v2IsInFrontOrBehind)
      {
        if (v1Classification == v2Classification)
        {
          if (v1Classification == PointClassifier.Classification.InFront)
          {
            return Classification.InFront;
          }

          return Classification.Behind;
        }

        return Classification.Spanning;
      }

      return Classification.Coincident;
    }

    //---------------------------------------------------------------------------------------------
  }
}