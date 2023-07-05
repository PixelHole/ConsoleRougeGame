using System;

namespace ConsoleGame.Engine.Entities.Components
{
    public class ShapeComponent : Component
    {
        public string Shape { get; private set; }
        public ConsoleColor Color { get; private set; }


        public ShapeComponent(string shape = "XX", ConsoleColor color = ConsoleColor.White)
        {
            Shape = shape;
            Color = color;
        }
    }
}