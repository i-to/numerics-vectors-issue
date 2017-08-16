using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StandaloneReproduction
{
    public class ReproductionSequence
    {
        public IReadOnlyList<Vector3> Initialize()
        {
            var vertices = new List<Vector3>();
            vertices.LastOrDefault();
            vertices.LastOrDefault();
            return vertices;
        }

        public Vector3 CreateNormal(IPlaneBuilder plane_builder)
        {
            Vector3 origin = new Vector3(0.9857f, 0.0484f, 0);
            Vector3 normal = new Vector3(0.7244056f, -0.6893741f, 0);
            var junction_plane = plane_builder.Create(origin, normal);
            return CalculateNormal(junction_plane, origin);
        }

        Vector3 CalculateNormal(IPlane plane, Vector3 origin)
        {
            var projection = plane.Project(new Vector3(1, 0, 0));
            var plane_normal = plane.N;
            var diff = projection - origin;
            if (!Almost.IsAlmostZero(diff.Length(), FloatingPointPrecision.Default))
            {
                return Vector3.Normalize(diff);
            }

            throw new InvalidOperationException();
            // This part is never executed, but removing the code below makes the issue go away.
            Vector3.Cross(plane_normal, Vector3.UnitX);
            return new Vector3(1, 0, 0);
        }

        public float GetLengthOfTheNormalizedVector()
        {
            Initialize();
            var normal = CreateNormal(new PlaneBuilder());
            return normal.Length();
        }
    }
}