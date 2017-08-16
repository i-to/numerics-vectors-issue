using System.Numerics;

namespace StandaloneReproduction
{
    public interface IPlane
    {
        Vector3 N { get; }
        Vector3 Project(Vector3 point);
    }

    public class Plane : IPlane
    {
        public Plane(Vector3 n, float d)
        {
            N = n;
            D = d;
        }

        public Plane(Vector3 point, Vector3 normal)
            : this(normal, -Vector3.Dot(point, normal))
        {
        }

        public float D { get; }
        public Vector3 N { get; }

        public float Distance(Vector3 v) => v.X * N.X + v.Y * N.Y + v.Z * N.Z + D;
        public Vector3 Project(Vector3 v) => v - Vector3.Multiply(Distance(v), N);
    }

    public interface IPlaneBuilder
    {
        Plane Create(Vector3 point, Vector3 normal);
    }

    public class PlaneBuilder : IPlaneBuilder
    {
        public Plane Create(Vector3 point, Vector3 normal) => new Plane(point, normal);
    }
}