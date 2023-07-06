namespace ConsoleGame.Engine.Units
{
    public class Bound
    {
        public Vector2Int TopLeft { get; private set; }
        public Vector2Int BottomRight { get; private set; }

        public int Width => BottomRight.x - TopLeft.x;
        public int Heigth => BottomRight.y - TopLeft.y;
        public Bound(Vector2Int topLeft, Vector2Int bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
    }
}