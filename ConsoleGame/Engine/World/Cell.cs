namespace ConsoleGame.Engine.World
{
    public class Cell
    {
        public string Shape { get; private set; }
        public bool Walkable { get; private set; }

        public Cell(string shape = ". ", bool walkable = true)
        {
            Shape = shape;
            Walkable = walkable;
        }
    }
}