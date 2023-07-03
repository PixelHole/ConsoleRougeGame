using System.Collections.Generic;
using ConsoleGame.Engine.World;

namespace ConsoleGame.GameManagers
{
    public static class SceneManager
    {
        public static List<Scene> Scenes { get; } = new List<Scene>();
        public static Scene CurrentScene { get; private set; }
    }
}