using System;
using ConsoleGame.Engine.Entities.Components;

namespace ConsoleGame.Engine.Entities.Instances
{
    public class Player : Creature
    {
        public Player(string name = "Player") : base(name, "PL", ConsoleColor.Yellow, 100)
        {
            AddComponent(new PlayerControlComponent());
        }
    }
}