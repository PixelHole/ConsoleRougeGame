namespace ConsoleGame.Engine.Units
{
    public class Vector3Int
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public Vector3Int(int x = 0, int y = 0, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        // --Units--
        /// <summary>
        /// Short-hand for writing new Vector3Int(0, 0, 0)
        /// </summary>
        public static Vector3Int Zero => new Vector3Int();
        /// <summary>
        /// Short-hand for writing new Vector3Int(1, 1, 1)
        /// </summary>
        public static Vector3Int one => new Vector3Int(1,1,1);
        /// <summary>
        /// Short-hand for writing new Vector3Int(-1, -1, -1)
        /// </summary>
        public static Vector3Int MinusOne => new Vector3Int(-1,-1,-1);
        /// <summary>
        /// Short-hand for writing new Vector3Int(0, 1, 0)
        /// </summary>
        public static Vector3Int Up => new Vector3Int(0, 1, 0);
        /// <summary>
        /// Short-hand for writing new Vector3Int(0, -1, 0)
        /// </summary>
        public static Vector3Int Down => new Vector3Int(0, -1, 0);
        /// <summary>
        /// Short-hand for writing new Vector3Int(-1, 0, 0)
        /// </summary>
        public static Vector3Int Left => new Vector3Int(-1, 0, 0);
        /// <summary>
        /// Short-hand for writing new Vector3Int(1, 0, 0)
        /// </summary>
        public static Vector3Int Right => new Vector3Int(1, 0, 0);
        /// <summary>
        /// Short-hand for writing new Vector3Int(0, 0, 1)
        /// </summary>
        public static Vector3Int Forward => new Vector3Int(0, 0, 1);
        /// <summary>
        /// Short-hand for writing new Vector3Int(0, 0, -1)
        /// </summary>
        public static Vector3Int Back => new Vector3Int(0, 0, -1);
        
        
        // --Operators--
        public static Vector3Int operator +(Vector3Int a, Vector3Int b)
            => new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3Int operator -(Vector3Int a, Vector3Int b)
            => new Vector3Int(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3Int operator *(Vector3Int a, int b)
            => new Vector3Int(a.x * b, a.y * b, a.z * b);
        public static Vector3Int operator *(int b, Vector3Int a)
            => new Vector3Int(a.x * b, a.y * b, a.z * b);
        public static Vector3Int operator /(Vector3Int a, int b)
            => new Vector3Int(a.x / b, a.y / b, a.z / b);
        
        
        // --Comparers--
        public static bool operator <(Vector3Int a, Vector3Int b)
            => a.x < b.x && a.y < b.y && a.z < b.z;
        public static bool operator >(Vector3Int a, Vector3Int b)
            => a.x > b.x && a.y > b.y && a.z > b.z;
        public static bool operator <=(Vector3Int a, Vector3Int b)
            => a.x <= b.x && a.y <= b.y && a.z <= b.z;
        public static bool operator >=(Vector3Int a, Vector3Int b)
            => a.x >= b.x && a.y >= b.y && a.z >= b.z;
        public static bool operator ==(Vector3Int a, Vector3Int b)
            => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=(Vector3Int a, Vector3Int b)
            => a.x != b.x || a.y != b.y || a.z != b.z;
        
        
        // --Casting--
        public static explicit operator Vector2Int(Vector3Int a)
            => new Vector2Int(a.x, a.y);
        public static explicit operator Vector3Int(Vector2Int a)
            => new Vector3Int(a.x, a.y);
    }
}