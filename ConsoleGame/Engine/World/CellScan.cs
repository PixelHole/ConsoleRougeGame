using System;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Engine.Entities.Components;

namespace ConsoleGame.Engine.World
{
    public class CellScan
    {
        public string Shape { get; private set; } = "  ";
        public ConsoleColor TopColor { get; private set; } = ConsoleColor.White;
        public ConsoleColor BottomColor { get; private set; } = ConsoleColor.Black;

        public CellScan(Cell cell)
        {
            SetShapeToCell(cell);
        }
        public CellScan(Entity entity)
        {
            SetShapeToEntity(entity);
        }
        public CellScan() { }
        public void SetShapeToCell(Cell cell)
        {
            if (cell == null) return;
            Shape = cell.Shape;
            TopColor = cell.TopColor;
            BottomColor = cell.BottomColor;
        }

        public void SetShapeToEntity(Entity entity)
        {
            if (!(entity?.GetComponent<ShapeComponent>() is ShapeComponent shapeComponent)) return;

            Shape = shapeComponent.Shape;
            TopColor = shapeComponent.TopColor;
            BottomColor = shapeComponent.BottomColor;
        }


        public static bool operator ==(CellScan a, CellScan b)
        {
            return a?.TopColor == b?.TopColor && a?.BottomColor == b?.BottomColor && a?.Shape == b?.Shape;
        }
        public static bool operator !=(CellScan a, CellScan b)
        {
            return a?.TopColor != b?.TopColor || a?.BottomColor != b?.BottomColor || a?.Shape != b?.Shape;
        }
    }
}