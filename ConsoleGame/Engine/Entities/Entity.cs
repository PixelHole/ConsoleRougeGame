using System.Collections.Generic;
using System.Linq;
using ConsoleGame.Engine.Entities.Components;

namespace ConsoleGame.Engine.Entities
{
    public abstract class Entity
    {
        public List<Component> Components = new List<Component>(new[] { new Transform() });
        public Transform Transform => Components[0] as Transform;

        public Component GetComponent<T>()
        {
            return Components.Find(component => component is T);
        }
    }
}