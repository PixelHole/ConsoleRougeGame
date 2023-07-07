﻿using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Engine.RenderEngine;
using ConsoleGame.Engine.Units;

namespace ConsoleGame.Engine.Entities.Components
{
    public class CameraFollowComponent : Component
    {
        private Transform Target;


        public override void Initialize()
        {
            Target = Owner.Transform;
            Target.OnMove += CheckForMovement;
        }

        private void CheckForMovement(Vector2Int movement)
        {
            if (Renderer.ViewBound.Heigth / 2 <= Target.Position.y && 
                Target.Position.y < SceneManager.CurrentScene.WorldYSize - Renderer.ViewBound.Heigth / 2)
            {
                Renderer.MoveViewBound(new Vector2Int(0, movement.y));
            }
            if (Renderer.ViewBound.Width / 2 <= Target.Position.x &&
                Target.Position.x < SceneManager.CurrentScene.WorldXSize - Renderer.ViewBound.Width / 2)
            {
                Renderer.MoveViewBound(new Vector2Int(movement.x, 0));
            }
        }
    }
}