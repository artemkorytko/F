using System;

namespace FLibrary
{
    [System.Serializable]
    public class Game
    {
        private int _size;
        private Map _map;
        private Coord _space;

        public int MovesCount { get; private set; }

        public Game(int size)
        {
            _size = size;
            _map = new Map(size);
        }

        public void Start(int seed = 0)
        {
            int digit = 0;

            // for (int y = 0; y < _size; y++)
            // {
            //     for (int x = 0; x < _size; x++)
            //     {
            //         _map.Set(new Coord(x, y), ++digit);
            //     }
            // }

            foreach (Coord xy in new Coord().YieldCoord(_size))
            {
                _map.Set(xy, ++digit);
            }

            _space = new Coord(_size);
            if (seed > 0)
            {
                Shuffle(seed);
            }

            MovesCount = 0;
        }

        private void Shuffle(int seed)
        {
            Random random = new Random(seed);
            for (int i = 0; i < seed; i++)
            {
                PressAt(random.Next(_size), random.Next(_size));
            }
        }

        public int PressAt(int x, int y)
        {
            return PressAs(new Coord(x, y));
        }

        private int PressAs(Coord coord)
        {
            if (_space.Equals(coord)) return 0;
            if (coord._x != _space._x && coord._y != _space._y) return 0;

            int steps = Math.Abs(coord._x - _space._x) + Math.Abs(coord._y - _space._y);

            while (coord._x != _space._x)
            {
                Shift(Math.Sign(coord._x - _space._x), 0);
            }

            while (coord._y != _space._y)
            {
                Shift(0, Math.Sign(coord._y - _space._y));
            }

            MovesCount += steps;
            return steps;
        }

        private void Shift(int sx, int sy)
        {
            Coord next = _space.Add(sx, sy);
            _map.Copy(next, _space);
            _space = next;
        }

        public int GetDigitAt(int x, int y)
        {
            return GetDigitAt(new Coord(x, y));
        }

        private int GetDigitAt(Coord xy)
        {
            if (_space.Equals(xy))
            {
                return 0;
            }

            return _map.Get(xy);
        }

        public bool Solved()
        {
            if (_space.Equals(new Coord(_size)))
                return false;

            int digit = 0;
            // for (int y = 0; y < _size; y++)
            // {
            //     for (int x = 0; x < _size; x++)
            //     {
            //         var xy = new Coord(x, y);
            //         if (++digit != _map.Get(xy))
            //         {
            //             return _space.Equals(xy);
            //         }
            //     }
            // }

            foreach (Coord xy in new Coord().YieldCoord(_size))
            {
                if (_map.Get(xy) != ++digit)
                {
                    return _space.Equals(xy);
                }
            }
            
            return true;
        }
    }
}