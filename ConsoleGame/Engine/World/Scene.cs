using System.Collections.Generic;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Units;

namespace ConsoleGame.Engine.World
{
    public class Scene
    {
        public string Name { get; private set; }
        public Cell[,,] World { get; private set; }
        public int WorldXSize=> World.GetLength(0);
        public int WorldYSize => World.GetLength(1);
        public int WorldZSize => World.GetLength(2);

        public List<Entity> Entities { get; } = new List<Entity>();

        public Cell[,] BasicScanArea(Bound bounds, int z)
        {
            Cell[,] scan = new Cell[bounds.Width, bounds.Heigth];

            for (int y = 0; y < bounds.Heigth; y++)
            {
                for (int x = 0; x < bounds.Width; x++)
                {
                    scan[x, y] = World[bounds.TopLeft.x + x, bounds.BottomRight.y + y, z];
                }
            }

            return scan;
        }
        public Cell BasicScanCellAt(Vector2Int pos, int z)
        {
            return World[pos.x, pos.y, z];
        }
    }
}