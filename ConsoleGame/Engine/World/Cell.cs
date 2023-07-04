using System;

namespace ConsoleGame.Engine.World
{
    public class Cell
    {
        public string Shape { get; private set; }
        public ConsoleColor Color { get; private set; }
        public bool Walkable { get; private set; }

        public Cell(string shape = ". ", ConsoleColor color = ConsoleColor.White, bool walkable = true)
        {
            Shape = shape;
            Color = color;
            Walkable = walkable;
        }

        public static bool operator ==(Cell a, Cell b)
        {
            return a?.Shape == b?.Shape && a?.Color == b?.Color && a?.Walkable == b?.Walkable;
        }
        public static bool operator !=(Cell a, Cell b)
        {
            return a?.Shape != b?.Shape || a?.Color != b?.Color || a?.Walkable != b?.Walkable;
        }
    }
}