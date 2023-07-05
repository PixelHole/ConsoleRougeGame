using System;
using ConsoleGame.Engine.Entities.Components;

namespace ConsoleGame.Engine.Entities.Instances
{
    public class Creature : Entity
    {
        protected HealthComponent HealthComponent => GetComponent<HealthComponent>() as HealthComponent;
        protected ShapeComponent ShapeComponent => GetComponent<ShapeComponent>() as ShapeComponent;
        
        public Creature(string name, string shape, ConsoleColor color, int health)
        {
            AddComponents(new HealthComponent(health), new ShapeComponent(shape, color));
        }
    }
}