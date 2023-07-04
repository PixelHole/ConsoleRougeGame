using System;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Engine.Entities.Components;

namespace ConsoleGame.Engine.World
{
    public class CellScan
    {
        public string Shape { get; private set; } = "  ";
        public ConsoleColor Color { get; private set; } = ConsoleColor.White;

        public CellScan(Cell cell)
        {
            SetShapeToCell(cell);
        }
        public CellScan(Entity entity)
        {
            SetShapeToEntity(entity);
        }
        public CellScan()
        {
            
        }
        public void SetShapeToCell(Cell cell)
        {
            if (cell == null) return;
            Shape = cell.Shape;
            Color = cell.Color;
        }

        public void SetShapeToEntity(Entity entity)
        {
            if (entity == null) return;
            ShapeComponent shapeComponent = entity.GetComponent<ShapeComponent>() as ShapeComponent;

            if (shapeComponent == null) return;

            Shape = shapeComponent.Shape;
            Color = shapeComponent.Color;
        }
    }
}