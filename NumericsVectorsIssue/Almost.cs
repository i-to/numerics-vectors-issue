using System;

namespace StandaloneReproduction
{
    public enum FloatingPointPrecision
    {
        Default
    }

    public static class Almost
    {
        public const double DefaultEpsilon = 1e-5;

        public static double GetEpsilon(FloatingPointPrecision precision)
        {
            // Stripped down to the single case, but cannot remove the switch completely
            // because this makes the issue go away.
            switch (precision)
            {
            case FloatingPointPrecision.Default:
                return DefaultEpsilon;
            }
            throw new ArgumentOutOfRangeException();
        }

        public static bool IsAlmostZero(double a, FloatingPointPrecision precision) =>
            IsAlmostZero(a, GetEpsilon(precision));

        public static bool IsAlmostZero(double a, double epsilon) =>
            Math.Abs(a) <= epsilon;
    }
}