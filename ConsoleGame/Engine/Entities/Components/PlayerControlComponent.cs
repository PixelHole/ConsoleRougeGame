using System;
using ConsoleGame.Engine.RenderEngine;

namespace ConsoleGame.Engine.Entities.Components
{
    public class PlayerControlComponent : ControlComponent
    {
        public override void Turn()
        {
            base.Turn();
            GetPlayerInput();
        }
        public override void EndTurn()
        {
            base.EndTurn();
            Renderer.UpdateView();
        }
        private void GetPlayerInput()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        MoveUp();
                        break;
                    case ConsoleKey.A:
                        MoveLeft();
                        break;
                    case ConsoleKey.S:
                        MoveDown();
                        break;
                    case ConsoleKey.D:
                        MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        break;
                    default:
                        continue;
                }

                break;
            }
            
            EndTurn();
        }
    }
}