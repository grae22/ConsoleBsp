namespace ConsoleBsp
{
  internal struct Line2d
  {
    //---------------------------------------------------------------------------------------------

    public Point2d Vertex1 { get; }
    public Point2d Vertex2 { get; }

    //---------------------------------------------------------------------------------------------

    public Line2d(in Point2d vertex1, in Point2d vertex2)
    {
      Vertex1 = vertex1;
      Vertex2 = vertex2;
    }

    //---------------------------------------------------------------------------------------------
  }
}
