using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Engine.Entities.Components;
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
        public Vector2Int HorizontalWorldSize => new Vector2Int(WorldXSize, WorldYSize);
        public List<Entity> Entities { get; private set; } = new List<Entity>();


        public Scene(string name, Cell[,,] world, List<Entity> entities)
        {
            Name = name;
            World = world;
            Entities = entities;
        }
        public Scene(Cell[,,] world, List<Entity> entities)
        {
            World = world;
            Entities = entities;
        }
        public Scene() {}

        
        // set data
        public void SetWorld(Cell[,,] world)
        {
            World = world;
        }
        public void SetEntities(List<Entity> entities)
        {
            Entities = entities;
        }
        
        
        // General scans
        public CellScan[,] BasicScanArea(Bound bounds, int OberserverZ)
        {
            if (OberserverZ < 1) throw new IndexOutOfRangeException("observer level too low. shouldn't be here");
            
            CellScan[,] scan = new CellScan[bounds.Width, bounds.Heigth];

            for (int y = 0; y < bounds.Heigth; y++)
            {
                for (int x = 0; x < bounds.Width; x++)
                {
                    scan[x, y] = new CellScan(World[bounds.TopLeft.x + x, bounds.TopLeft.y + y, OberserverZ - 1]);
                }
            }

            foreach (var entity in GetEntitiesInArea(bounds, OberserverZ))
            {
                Vector2Int indexPos = entity.Transform.Position - bounds.TopLeft;
                scan[indexPos.x, indexPos.y].SetShapeToEntity(entity);
            }

            return scan;
        }
        public CellScan BasicScanCellAt(Vector2Int pos, int z)
        {
            Entity entity = GetEntityAt(pos, z);
            if (entity == null)
            {
                return new CellScan(World[pos.x, pos.y, z - 1]);
            }

            return new CellScan(entity);
        }
        
        
        // entity scans
        public List<Entity> GetEntitiesInArea(Bound bounds, int z)
        {
            return Entities.Where(entity =>
                    entity.Transform.Position <= bounds.BottomRight && entity.Transform.Position >= bounds.TopLeft && 
                    entity.Transform.Z == z)
                .ToList();
        }
        public Entity GetEntityAt(Vector2Int pos, int z)
        {
            return Entities.Find(entity => entity.Transform.Position == pos && entity.Transform.Z == z);
        }
        
        
        // Checks
        public bool IsPositionInBounds(Vector2Int pos)
            => pos > Vector2Int.MinusOne && pos < HorizontalWorldSize;
    }
}