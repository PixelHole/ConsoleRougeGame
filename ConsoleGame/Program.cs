using System;
using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Engine.Renderer;

namespace ConsoleGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SceneManager.AddTestScene();
            Renderer.Initialize();

            Console.ReadKey();
        }
    }
}