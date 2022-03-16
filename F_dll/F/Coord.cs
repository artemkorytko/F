using System.Collections.Generic;

namespace FLibrary
{
    public struct Coord
    {
        public int _x;
        public int _y;

        public Coord(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Coord(int size)
        {
            _x = size - 1;
            _y = size - 1;
        }

        public Coord Add(int sx, int sy)
        {
            return new Coord(_x + sx, _y + sy);
        }

        public bool IsOnBoard(int size)
        {
            if (_x < 0 || _x > size - 1) return false;
            if (_y < 0 || _y > size - 1) return false;
            return true;
        }

        public IEnumerable<Coord> YieldCoord(int size)
        {
            for (_y = 0; _y < size; _y++)
            {
                for (_x = 0; _x < size; _x++)
                {
                    yield return this;
                }
            }
        }
    }
}