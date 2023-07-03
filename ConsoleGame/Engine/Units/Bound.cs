namespace ConsoleGame.Units
{
    public class Bound
    {
        public Vector2Int TopLeft { get; private set; }
        public Vector2Int BottomRight { get; private set; }

        public int Width => TopLeft.x - BottomRight.x;
        public int Heigth => TopLeft.y - BottomRight.y;
        public Bound(Vector2Int topLeft, Vector2Int bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
    }
}