namespace ConsoleGame.Engine.Entities.Components
{
    public abstract class Component
    {
        public Entity Owner { get; private set; }

        public Component() {}

        public void SetOwner(Entity owner)
        {
            if (owner == null) Owner = owner;
        }
    }
}