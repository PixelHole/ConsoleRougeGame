namespace ConsoleGame.Units
{
    public class Vector2Int
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2Int()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        // -- Units --
        /// <summary>
        /// Short-Hand for writing new Vector2Int(0, 0)
        /// </summary>
        public static Vector2Int Zero => new Vector2Int(0, 0);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(1, 1)
        /// </summary>
        public static Vector2Int One => new Vector2Int(1, 1);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(-1, -1)
        /// </summary>
        public static Vector2Int MinusOne => new Vector2Int(-1, -1);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(0, 1)
        /// </summary>
        public static Vector2Int Up => new Vector2Int(0, 1);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(0, -1)
        /// </summary>
        public static Vector2Int Down => new Vector2Int(0, -1);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(-1, 0)
        /// </summary>
        public static Vector2Int Left => new Vector2Int(-1, 0);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(1, 0)
        /// </summary>
        public static Vector2Int Right => new Vector2Int(1, 0);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(-1, 1)
        /// </summary>
        public static Vector2Int UpLeft => new Vector2Int(-1, 1);
        /// <summary>
        /// Short-Hand for writing new Vector2Int(1, -1)
        /// </summary>
        public static Vector2Int DownRight => new Vector2Int(1, -1);

        // -- Operators --
        // Sum operator
        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
            => new Vector2Int(a.x + b.x, a.y + b.y);
        
        // Reduction operator
        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
            => new Vector2Int(a.x - b.x, a.y - b.y);
        
        // Multiply operators
        public static Vector2Int operator *(int a, Vector2Int b)
            => new Vector2Int(b.x * a, b.y * a);
        
        public static Vector2Int operator *(Vector2Int b, int a)
            => new Vector2Int(b.x * a, b.y * a);
        
        // division operator
        public static Vector2Int operator /(Vector2Int b, int a)
            => new Vector2Int(b.x / a, b.y / a);
        
        // -- Comparers -- 
        public static bool operator <(Vector2Int a, Vector2Int b)
            => a.x < b.x && a.y < b.y;
        
        public static bool operator >(Vector2Int a, Vector2Int b)
            => a.x > b.x && a.y > b.y;
        
        public static bool operator <=(Vector2Int a, Vector2Int b)
            => a.x <= b.x && a.y <= b.y;
        
        public static bool operator >=(Vector2Int a, Vector2Int b)
            => a.x >= b.x && a.y >= b.y;
        
        public static bool operator ==(Vector2Int a, Vector2Int b)
            => a.x == b.x && a.y == b.y;

        public static bool operator !=(Vector2Int a, Vector2Int b)
            => a.x != b.x || a.y != b.y;
    }
}