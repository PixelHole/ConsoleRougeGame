using System;

namespace ConsoleGame.Engine.Entities.Components
{
    public class ShapeComponent : Component
    {
        public string Shape { get; private set; }
        public ConsoleColor TopColor { get; private set; }
        public ConsoleColor BottomColor { get; private set; }


        public ShapeComponent(string shape = "XX",
            ConsoleColor topColor = ConsoleColor.White,
            ConsoleColor bottomColor = ConsoleColor.Black)
        {
            Shape = shape;
            TopColor = topColor;
            BottomColor = bottomColor;
        }
    }
}