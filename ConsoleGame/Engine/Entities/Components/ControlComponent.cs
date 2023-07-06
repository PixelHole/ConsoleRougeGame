using ConsoleGame.Engine.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public abstract class ControlComponent : Component
    {
        public delegate void TurnTrigger();
        public delegate void TurnEndTrigger();
        public event TurnTrigger OnTurn;
        public event TurnEndTrigger OnTurnEnd;


        public virtual void Turn()
        {
            OnTurn?.Invoke();
        }
        public virtual void EndTurn()
        {
            OnTurnEnd?.Invoke();
        }
        protected virtual void Move(Vector2Int movement)
        {
            Owner.Transform.Move(movement, true);
        }
        
        protected virtual void MoveLeft(int distance = 1) => Move(Vector2Int.Left * distance);
        protected virtual void MoveRight(int distance = 1) => Move(Vector2Int.Right * distance);
        protected virtual void MoveUp(int distance = 1) => Move(Vector2Int.Down * distance);
        protected virtual void MoveDown(int distance = 1) => Move(Vector2Int.Up * distance);
    }
}