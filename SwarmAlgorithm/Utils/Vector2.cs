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

        public override string ToString()
        {
            return $"Vector2({X}, {Y})";
        }
    }
}