namespace ConsoleGame.Engine.Entities.Components
{
    public abstract class Component
    {
        public Entity Owner { get; private set; } = null;

        public Component() {}

        public void SetOwner(Entity owner)
        {
            Owner = owner;
        }
    }
}