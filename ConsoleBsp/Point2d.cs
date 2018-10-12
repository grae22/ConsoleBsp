using ConsoleBsp.Extensions;

namespace ConsoleBsp
{
  internal class Point2d
  {

    //---------------------------------------------------------------------------------------------

    public double X { get; set; }
    public double Y { get; set; }

    //---------------------------------------------------------------------------------------------

    public Point2d(double x, double y)
    {
      X = x;
      Y = y;
    }

    //---------------------------------------------------------------------------------------------

    public static bool operator ==(in Point2d p1, in Point2d p2)
    {
      return (p1.X - p2?.X).IsZero() && (p1.Y - p2?.Y).IsZero();
    }

    //---------------------------------------------------------------------------------------------

    public static bool operator !=(in Point2d p1, in Point2d p2)
    {
      return !(p1 == p2);
    }

    //---------------------------------------------------------------------------------------------

    public override bool Equals(object other)
    {
      if (other is Point2d otherAsPoint)
      {
        return this == otherAsPoint;
      }

      return base.Equals(other);
    }

    //---------------------------------------------------------------------------------------------

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    //---------------------------------------------------------------------------------------------
  }
}
