using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Engine.RenderEngine;
using ConsoleGame.Engine.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public class Transform : Component
    {
        public Vector3Int Position { get; set; }

        public delegate void MoveTrigger(Vector3Int movement);
        public event MoveTrigger OnMove;

        public Transform(Vector3Int position)
        {
            Position = position;
        }
        public Transform() : this(Vector3Int.Zero) {}
        
        public void Move(Vector3Int movement, bool clampToWorld)
        {
            Vector3Int destination = Position + movement;

            // world bound check
            if (clampToWorld &&
                !SceneManager.CurrentScene.IsPositionInBounds(destination))
                return;
            
            // world collision check
            if (!SceneManager.CurrentScene.CanMoveToCell(destination))
            {
                // Climbing
                if (SceneManager.CurrentScene.CanClimbCell(destination) &&
                    SceneManager.CurrentScene.IsZInBounds(destination.z + 1))
                {
                    destination.z++;
                    movement.z++;
                }
                
            }

            // event invoking
            if (movement != Vector3Int.Zero) OnMove?.Invoke(movement);
            
            Position = destination;
        }
    }
}