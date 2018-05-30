using System;

namespace ConsoleBsp
{
  internal static class MathUtils
  {
    //---------------------------------------------------------------------------------------------

    public const double Epsilon = 0.001;

    //---------------------------------------------------------------------------------------------

    public static bool IsZero(double value)
    {
      return Math.Abs(value) < Epsilon;
    }

    //---------------------------------------------------------------------------------------------
  }
}
