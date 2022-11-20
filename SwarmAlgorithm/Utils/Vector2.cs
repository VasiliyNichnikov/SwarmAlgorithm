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

        public static Vector2 operator *(Vector2 first, float[] second)
        {
            if (second.Length != 2)
            {
                throw new Exception(); // todo нужно отфильтровать ошибку
            }

            return first * new Vector2(second[0], second[1]);
        }
    }
}