using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Engine.Entities.Components;
using ConsoleGame.Engine.Units;

namespace ConsoleGame.Engine.World
{
    public class Scene
    {
        public string Name { get; private set; }
        private Cell[,,] World { get; set; }
        public int WorldXSize=> World.GetLength(0);
        public int WorldYSize => World.GetLength(1);
        public int WorldZSize => World.GetLength(2);
        public Vector2Int HorizontalWorldSize => new Vector2Int(WorldXSize, WorldYSize);
        private List<Entity> Entities { get; set; } = new List<Entity>();


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
        
        
        // Entity Manipulation
        public void SpawnEntity(Entity entity, Vector2Int position, int z)
        {
            if (!IsPositionInBounds(position)) throw new IndexOutOfRangeException();

            entity.Transform.Position = position;
            entity.Transform.Z = z;
            
            Entities.Add(entity);
        }
        public void DestroyEntity(Entity entity)
        {
            Entities.Remove(entity);
        }
        public List<ControlComponent> GetActiveEntities()
        {
            return Entities.Select(entity => entity.GetComponent<ControlComponent>()).OfType<ControlComponent>().ToList();
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
                    if (World[bounds.TopLeft.x + x, bounds.TopLeft.y + y, OberserverZ] != null)
                    {
                        scan[x, y] = new CellScan();
                        continue;
                    }
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
                    entity.Transform.Position < bounds.BottomRight && entity.Transform.Position >= bounds.TopLeft && 
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