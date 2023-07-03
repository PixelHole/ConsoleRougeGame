using System.Collections.Generic;
using ConsoleGame.Engine.Entities;

namespace ConsoleGame.Engine.World
{
    public class Scene
    {
        public Cell[,,] World { get; private set; }
        public int WorldXSize=> World.GetLength(0);
        public int WorldYSize => World.GetLength(1);
        public int WorldZSize => World.GetLength(2);

        public List<Entity> Entities { get; } = new List<Entity>();
    }
}