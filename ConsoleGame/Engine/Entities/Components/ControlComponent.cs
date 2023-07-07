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
        protected virtual void Move(Vector3Int movement)
        {
            Owner.Transform.Move(movement, true);
        }
        
        protected virtual void MoveLeft(int distance = 1) => Move(Vector3Int.Left * distance);
        protected virtual void MoveRight(int distance = 1) => Move(Vector3Int.Right * distance);
        protected virtual void MoveUp(int distance = 1) => Move(Vector3Int.Down * distance);
        protected virtual void MoveDown(int distance = 1) => Move(Vector3Int.Up * distance);
        protected virtual void Climb(int distance = 1) => Move(Vector3Int.Forward);
    }
}