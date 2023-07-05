using System;
using ConsoleGame.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public class PlayerControlComponent : ControlComponent
    {
        protected override void Turn()
        {
            base.Turn();
            GetPlayerInput();
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