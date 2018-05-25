namespace ConsoleBsp
{
  internal struct Line2d
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
