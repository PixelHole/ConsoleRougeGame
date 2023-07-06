using System.Collections.Generic;
using ConsoleGame.Engine.Entities.Components;
using ConsoleGame.Engine.RenderEngine;

namespace ConsoleGame.Engine.GameManagers
{
    public static class GameManager
    {
        private static List<ControlComponent> ActiveEntities = new List<ControlComponent>();
        private static int ActiveEntityIndex;

        public static void StartGame()
        {
            SceneManager.OnSceneChange += GetActiveEntities;
            SceneManager.AddTestScene();
            Renderer.Initialize();

            while (true)
            {
                SignalTurnToEntity();
            }
        }
        private static void GetActiveEntities()
        {
            ActiveEntities = SceneManager.CurrentScene.GetActiveEntities();
        }
        private static void TurnEnd()
        {
            ActiveEntities[ActiveEntityIndex].OnTurnEnd -= TurnEnd;
            
            ActiveEntityIndex++;
            if (ActiveEntityIndex >= ActiveEntities.Count) ActiveEntityIndex = 0;
        }
        private static void SignalTurnToEntity()
        {
            ActiveEntities[ActiveEntityIndex].OnTurnEnd += TurnEnd;
            ActiveEntities[ActiveEntityIndex].Turn();
        }
    }
}