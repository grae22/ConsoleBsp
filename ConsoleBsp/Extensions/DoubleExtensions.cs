using System;

namespace ConsoleBsp.Extensions
{
  internal static class DoubleExtensions
  {
    private const double Epsilon = 0.001;

    public static bool IsZero(this double value, double epsilon = Epsilon)
    {
      return Math.Abs(value) < double.Epsilon;
    }

    public static bool IsZero(this double? value, double epsilon = Epsilon)
    {
      if (!value.HasValue)
      {
        return false;
      }

      return Math.Abs(value.Value) < double.Epsilon;
    }
  }
}
