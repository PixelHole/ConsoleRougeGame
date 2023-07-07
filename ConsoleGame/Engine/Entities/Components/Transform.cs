using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Engine.RenderEngine;
using ConsoleGame.Engine.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public class Transform : Component
    {
        public Vector2Int Position { get; set; }
        public int Z { get; set; }

        public delegate void MoveTrigger(Vector2Int movement);
        public event MoveTrigger OnMove;

        public Transform(Vector2Int position, int z = 0)
        {
            Position = position;
            Z = z;
        }
        public Transform() : this(Vector2Int.Zero) {}
        
        public void Move(Vector2Int movement, bool clampToWorld)
        {
            if (clampToWorld && !SceneManager.CurrentScene.IsPositionInBounds(Position + movement))
            {
                Vector2Int worldSize = SceneManager.CurrentScene.HorizontalWorldSize;

                if (Position.x + movement.x > worldSize.x) Position.x = worldSize.x - 1;
                if (Position.y + movement.y > worldSize.y) Position.y = worldSize.y - 1;
                
                return;
            }
            
            if (movement != Vector2Int.Zero) OnMove?.Invoke(movement);
            
            Position += movement;
        }
    }
}