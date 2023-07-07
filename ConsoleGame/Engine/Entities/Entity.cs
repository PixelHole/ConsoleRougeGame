using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleGame.Engine.Entities.Components;
using ConsoleGame.Engine.Exceptions;

namespace ConsoleGame.Engine.Entities
{
    public abstract class Entity
    {
        /// <summary>
        /// The name of the entity
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// A list of this Entity's Components, the scripts that drive its behavior. Never EVER add to this list
        /// Directly! if you do, make sure to assign the Component's Owner Manually
        /// </summary>
        private List<Component> Components = new List<Component>();
        
        /// <summary>
        /// Quick Access to this Entity's Transform Component
        /// </summary>
        public readonly Transform Transform = new Transform();

        protected Entity(string name = "Entity", params Component[] components)
        {
            Name = name;
            if (components.Length > 0) Components.AddRange(components);
        }

        
        // component List Manipulation
        
        /// <summary>
        /// Adds a list of components to this Entity's Component list, throws an exception if a component is already added
        /// </summary>
        /// <param name="components">the components to add</param>
        public void AddComponents(params Component[] components)
        {
            foreach (Component component in components)
            {
                try
                {
                    AddComponent(component);
                }
                catch (DuplicateComponentException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        
        /// <summary>
        /// Adds a component to this entity's component list, throws an exception if component is already added
        /// </summary>
        /// <param name="component">The component to add</param>
        /// <exception cref="DuplicateComponentException">when the given component is already added to the list,
        /// this exception is thrown</exception>
        public void AddComponent(Component component)
        {
            if (Components.Contains(component)) throw new DuplicateComponentException();

            component.SetOwner(this);
            
            Components.Add(component);
            
            component.Initialize();
        }
        
        /// <summary>
        /// Removes the first occurence of a component if it exists in the component list
        /// </summary>
        /// <param name="component">the type of the component</param>
        public void RemoveComponent(Component component)
        {
            Components.Remove(component);
        }
        
        /// <summary>
        /// Find the first occurence of a component
        /// </summary>
        /// <typeparam name="T">the type of the component</typeparam>
        /// <returns></returns>
        public Component GetComponent<T>()
        {
            return Components.Find(component => component is T);
        }
    }
}