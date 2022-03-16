namespace FLibrary
{
    [System.Serializable]
    public class Map
    {
        private int _size;
        private int[,] _map;

        public Map(int size)
        {
            _size = size;
            _map = new int[size, size];
        }

        public void Set(Coord xy, int value)
        {
            if (xy.IsOnBoard(_size))
            {
                _map[xy._x, xy._y] = value;
            }
        }

        public int Get(Coord xy)
        {
            if (xy.IsOnBoard(_size))
            {
                return _map[xy._x, xy._y];
            }

            return 0;
        }

        public void Copy(Coord from, Coord to)
        {
            Set(to, Get(from));
        }
    }
}