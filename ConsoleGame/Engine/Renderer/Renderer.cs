using System;
using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Engine.World;
using ConsoleGame.Units;

namespace ConsoleGame.Engine.Renderer
{
    public static class Renderer
    {
        public static Cell[,] View { get; private set; }
        public static Bound ViewBound { get; private set; }
        public static Bound ScreenBound { get; private set; }
        public static int ZLevel { get; private set; }
        public static Vector2Int CellRenderSize { get; private set; } = new Vector2Int(2, 1);
        private static Vector2Int CursorRestPosition = new Vector2Int(0, 10);
        
        
        // Update View
        public static void InitializeView()
        {
            View = SceneManager.CurrentScene.BasicScanArea(ViewBound, ZLevel);
            DrawArea(View, ViewBound, false);
        }
        public static void UpdateView()
        {
            Cell[,] newView = SceneManager.CurrentScene.BasicScanArea(ViewBound, ZLevel);

            for (int y = 0; y < ViewBound.Heigth; y++)
            {
                for (int x = 0; x < ViewBound.Width; x++)
                {
                    if (View[x, y] != newView[x, y])
                    {
                        DrawPixel(newView[x, y], IndexToScreenPosition(new Vector2Int(x, y)), true);
                        View[x, y] = newView[x, y];
                    }
                }
            }
        }
        public static void UpdateViewAt(Vector2Int pos)
        {
            Cell newCell = SceneManager.CurrentScene.BasicScanCellAt(pos, ZLevel);

            if (View[pos.x, pos.y] != newCell)
            {
                DrawPixel(newCell, IndexToScreenPosition(new Vector2Int(pos.x, pos.y)), true);
                View[pos.x, pos.y] = newCell;
            }
        }


        // Drawing
        public static void DrawArea(Cell[,] scan, Bound bound, bool erase)
        {
            for (int y = 0; y < scan.GetLength(1); y++)
            {
                for (int x = 0; x < scan.GetLength(0); x++)
                {
                    DrawPixel(scan[x, y], new Vector2Int(x, y) + bound.TopLeft, erase);
                }
            }
        }
        public static void DrawPixel(Cell cell, Vector2Int screenPos, bool erase)
        {
            if (erase) ErasePixel(screenPos);
            
            SetCursorPosition(screenPos);
            
            SetCursorColor(cell.Color);
            
            Console.Write(cell.Shape);
            
            RestCursor();
        }
        public static void ErasePixel(Vector2Int screenPos)
        {
            screenPos.x += CellRenderSize.x;

            SetCursorPosition(screenPos);
            
            for (int i = 0; i < CellRenderSize.x; i++)
            {
                Console.Write('\b');
            }
            
            RestCursor();
        }
        
        
        // Cursor Management
        private static void SetCursorColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        private static void RestCursor()
        {
            SetCursorPosition(CursorRestPosition);
        }
        private static void SetCursorPosition(Vector2Int pos)
        {
            Console.CursorLeft = pos.x;
            Console.CursorTop = pos.y;
        }

        
        // Utility
        private static Vector2Int IndexToScreenPosition(Vector2Int pos)
        {
            return new Vector2Int(pos.x * CellRenderSize.x, pos.y * CellRenderSize.y);
        }
        public static Vector2Int WorldToScreenPosition(Vector2Int worldPos)
        {
            worldPos -= ViewBound.TopLeft;
            return new Vector2Int(worldPos.x * CellRenderSize.x, worldPos.y * CellRenderSize.y);
        }
        public static Vector2Int ScreenToWorldPosition(Vector2Int screenPos)
        {
            screenPos += ViewBound.TopLeft;
            return new Vector2Int(screenPos.x / CellRenderSize.x, screenPos.y / CellRenderSize.y);
        }
    }
}