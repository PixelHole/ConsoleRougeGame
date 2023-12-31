﻿using System;

namespace ConsoleGame.Engine.World
{
    public class Cell
    {
        public string Shape { get; private set; }
        public ConsoleColor TopColor { get; private set; }
        public ConsoleColor BottomColor { get; private set; }
        public bool Walkable { get; private set; }
        public bool Climbable { get; private set; }

        public Cell(string shape = ". ",
            ConsoleColor topColor = ConsoleColor.White,
            ConsoleColor bottomColor = ConsoleColor.Black,
            bool walkable = true,
            bool climbable = true)
        {
            Shape = shape;
            TopColor = topColor;
            BottomColor = bottomColor;
            Walkable = walkable;
            Climbable = climbable;
        }

        public static bool operator ==(Cell a, Cell b)
        {
            return a?.Shape == b?.Shape &&
                   a?.TopColor == b?.TopColor &&
                   a?.BottomColor == b?.BottomColor &&
                   a?.Walkable == b?.Walkable &&
                   a?.Climbable == b?.Climbable;
        }
        public static bool operator !=(Cell a, Cell b)
        {
            return a?.Shape != b?.Shape ||
                   a?.TopColor != b?.TopColor ||
                   a?.BottomColor != b?.BottomColor ||
                   a?.Walkable != b?.Walkable ||
                   a?.Climbable != b?.Climbable;
        }
    }
}