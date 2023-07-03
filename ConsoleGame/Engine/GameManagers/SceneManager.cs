using System.Collections.Generic;
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
    }
}