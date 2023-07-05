using ConsoleGame.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public abstract class ControlComponent : Component
    {
        protected delegate void TurnTrigger();
        protected delegate void TurnEndTrigger();
        protected event TurnTrigger OnTurn;
        protected event TurnEndTrigger OnTurnEnd;


        protected virtual void Turn()
        {
            OnTurn?.Invoke();
        }
        protected virtual void EndTurn()
        {
            OnTurnEnd?.Invoke();
        }
        protected virtual void Move(Vector2Int movement)
        {
            Owner.Transform.Move(movement, true);
        }
        
        protected virtual void MoveLeft(int distance = 1) => Move(Vector2Int.Left * distance);
        protected virtual void MoveRight(int distance = 1) => Move(Vector2Int.Right * distance);
        protected virtual void MoveUp(int distance = 1) => Move(Vector2Int.Up * distance);
        protected virtual void MoveDown(int distance = 1) => Move(Vector2Int.Down * distance);
    }
}