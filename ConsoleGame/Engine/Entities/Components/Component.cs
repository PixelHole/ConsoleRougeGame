namespace ConsoleGame.Engine.Entities.Components
{
    public abstract class Component
    {
        /// <summary>
        /// the owner of the component
        /// </summary>
        public Entity Owner { get; private set; }
        

        /// <summary>
        /// a virtual function for doing any pre work related to the components, i.e setting fields, adding to events ect...
        /// </summary>
        public virtual void Initialize() { }

        
        /// <summary>
        /// Sets the owner of this component. you really shouldn't touch it
        /// </summary>
        /// <param name="owner"></param>
        public void SetOwner(Entity owner)
        {
            Owner = owner;
        }
    }
}