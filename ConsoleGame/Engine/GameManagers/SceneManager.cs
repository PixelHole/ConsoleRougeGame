using System;
using System.Collections.Generic;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Engine.World;

namespace ConsoleGame.Engine.GameManagers
{
    public static class SceneManager
    {
        public static List<Scene> Scenes { get; } = new List<Scene>();
        public static int CurrentSceneIndex { get; private set; }
        public static Scene CurrentScene => Scenes[CurrentSceneIndex];

        public static void AddScene(Scene scene)
        {
            if (Scenes.Contains(scene)) return;
            
            Scenes.Add(scene);
        }
        public static void SetCurrentScene(int index)
        {
            if (index > Scenes.Count || index < 0) return;

            CurrentSceneIndex = index;
        }
        public static void SetCurrentScene(string name)
        {
            SetCurrentScene(FindSceneIndexWithName(name));
        }
        public static int FindSceneIndexWithName(string name)
            => Scenes.FindIndex(scene => scene.Name == name);

        public static void AddTestScene()
        {
            Cell[,,] world = new Cell[100,100,3];

            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    world[x, y, 0] = new Cell();
                }
            }
            for (int y = 5; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    world[x, y, 1] = new Cell();
                }
            }

            world[6, 6, 0] = new Cell("0", ConsoleColor.Blue);
            world[6, 6, 1] = new Cell("1", ConsoleColor.Red);
            world[6, 6, 2] = new Cell("2", ConsoleColor.Magenta);
            
            Scene scene = new Scene("test", world, new List<Entity>());

            SetCurrentScene("test");
            
            AddScene(scene);
        }
    }
}