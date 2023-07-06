using System;
using System.Collections.Generic;
using ConsoleGame.Engine.Entities;
using ConsoleGame.Engine.Entities.Instances;
using ConsoleGame.Engine.Units;
using ConsoleGame.Engine.World;

namespace ConsoleGame.Engine.GameManagers
{
    public static class SceneManager
    {
        private static List<Scene> Scenes { get; } = new List<Scene>();
        private static int CurrentSceneIndex { get; set; } = -1;
        public static Scene CurrentScene => Scenes[CurrentSceneIndex];

        public delegate void SceneChangeTrigger();
        public static event SceneChangeTrigger OnSceneChange;

        public static void AddScene(Scene scene)
        {
            if (Scenes.Contains(scene)) return;
            
            Scenes.Add(scene);
        }
        public static void SetCurrentScene(int index)
        {
            if (index > Scenes.Count || index < 0) return;

            bool sceneChange = CurrentSceneIndex != index;

            CurrentSceneIndex = index;
            
            if (sceneChange) OnSceneChange?.Invoke();
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

            world[0, 0, 0] = new Cell("0 ", ConsoleColor.Blue);
            world[6, 6, 1] = new Cell("1 ", ConsoleColor.Red);
            world[6, 6, 2] = new Cell("2 ", ConsoleColor.Magenta);

            Scene scene = new Scene("test", world, new List<Entity>());
            
            scene.SpawnEntity(new Player(), new Vector2Int(1, 1), 1);

            AddScene(scene);
            
            SetCurrentScene("test");
        }
    }
}