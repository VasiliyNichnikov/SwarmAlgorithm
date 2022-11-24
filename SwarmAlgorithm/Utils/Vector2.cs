using System;

namespace SwarmAlgorithm.Utils
{
    public struct Vector2
    {
        public float X { get; }
        public float Y { get; }

        public static Vector2 Zero => new Vector2(0, 0);

        public static Vector2 RandomFromZeroToOne
        {
            get
            {
                float x = RandomWrap.NextFloat();
                float y = RandomWrap.NextFloat();

                return new Vector2(x, y);
            }
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float SumOfElements()
        {
            return X + Y;
        }

        public static Vector2 operator +(Vector2 first, Vector2 second)
        {
            return new Vector2(first.X + second.X, first.Y + second.Y);
        }

        public static Vector2 operator *(Vector2 first, Vector2 second)
        {
            return new Vector2(first.X * second.X, first.Y * second.Y);
        }

        public static Vector2 operator -(Vector2 first, Vector2 second)
        {
            return new Vector2(second.X - first.X, second.Y - first.Y);
        }

        public static Vector2 operator *(Vector2 first, float second)
        {
            return new Vector2(first.X * second, first.Y * second);
        }

        public static Vector2 operator *(float first, Vector2 second)
        {
            return new Vector2(second.X * first, second.Y * first);
        }

        public static Vector2 operator -(Vector2 first)
        {
            return new Vector2(-first.X, -first.Y);
        }

        public static bool operator <(Vector2 first, Vector2 second)
        {
            return first.X < second.X || first.Y < second.Y;
        }

        public static bool operator >(Vector2 first, Vector2 second)
        {
            return first.X > second.X || first.Y > second.Y;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            float x2 = (float)Math.Pow(a.X - b.X, 2);
            float y2 = (float)Math.Pow(a.Y - b.Y, 2);
            return (float)Math.Sqrt(x2 + y2);
        }

        public static Vector2 Abs(Vector2 value)
        {
            return new Vector2(Math.Abs(value.X), Math.Abs(value.Y));
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
            // return $"Vector2({X}, {Y})";
        }
    }
}