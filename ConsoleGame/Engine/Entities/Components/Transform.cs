using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public class Transform : Component
    {
        public Vector2Int Position { get; set; }
        public Vector2Int Direction { get; set; }
        public int Z { get; private set; }

        public void Move(Vector2Int movement, bool clampToWorld)
        {
            if (clampToWorld && !SceneManager.CurrentScene.IsPositionInBounds(Position + movement))
            {
                Vector2Int worldSize = SceneManager.CurrentScene.HorizontalWorldSize;

                if (Position.x + movement.x > worldSize.x) Position.x = worldSize.x - 1;
                if (Position.y + movement.y > worldSize.y) Position.y = worldSize.y - 1;
                
                return;
            }
            Position += movement;
        }
    }
}