using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position left, Position right)
        {
            return new Position(left.X + right.X, left.Y + right.Y);
        }

        public static Position operator -(Position left, Position right)
        {
            return new Position(left.X - right.X, left.Y - right.Y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return (left.X == right.X) && (left.Y == right.Y);
        }

        public static bool operator !=(Position left, Position right)
        {
            return (left.X != right.X) && (left.Y != right.Y);
        }
    }
}
