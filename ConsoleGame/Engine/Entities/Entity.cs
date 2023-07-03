using ConsoleGame.Engine.Entities.Components;

namespace ConsoleGame.Engine.Entities
{
    public abstract class Entity
    {
        public Transform Transform { get; private set; }
    }
}