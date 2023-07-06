using System;
using ConsoleGame.Engine.GameManagers;
using ConsoleGame.Engine.Units;
using ConsoleGame.Engine.World;

namespace ConsoleGame.Engine.RenderEngine
{
    public static class Renderer
    {
        private static CellScan[,] View { get; set; }
        public static Bound ViewBound { get; private set; }
        public static Vector2Int ScreenBound { get; private set; } = new Vector2Int(2, 1);
        public static int ZLevel { get; private set; }
        public static Vector2Int CellRenderSize { get; private set; } = new Vector2Int(2, 1);
        private static Vector2Int CursorRestPosition => new Vector2Int(0, ViewBound.Heigth + 1);

        public delegate void ViewBoundMoveTrigger();
        public static event ViewBoundMoveTrigger OnViewBoundChange;
        
        // Initialization
        public static void Initialize()
        {
            ViewBound = new Bound(Vector2Int.Zero, Vector2Int.One * 15);
            ZLevel = 1;
            InitializeView();
        }
        
        
        // Update View Bounds
        public static void MoveViewBound(Vector2Int movement)
        {
            Bound result = ViewBound + movement;
            
            if (!SceneManager.CurrentScene.IsPositionInBounds(result.TopLeft) ||
                !SceneManager.CurrentScene.IsPositionInBounds(result.BottomRight)) return;

            SetViewBound(result);
        }
        public static void SetViewBound(Bound newBound)
        {
            OnViewBoundChange?.Invoke();
            ViewBound = newBound;
        }


        // Update View
        public static void InitializeView()
        {
            View = SceneManager.CurrentScene.BasicScanArea(ViewBound, ZLevel);
            DrawArea(View, ViewBound, false);
        }
        public static void UpdateView()
        {
            CellScan[,] newView = SceneManager.CurrentScene.BasicScanArea(ViewBound, ZLevel);

            for (int y = 0; y < ViewBound.Heigth; y++)
            {
                for (int x = 0; x < ViewBound.Width; x++)
                {
                    if (View[x, y] != newView[x, y])
                    {
                        DrawPixel(newView[x, y], new Vector2Int(x, y), true);
                        View[x, y] = newView[x, y];
                    }
                }
            }
        }
        public static void UpdateViewAt(Vector2Int pos)
        {
            CellScan newCell = SceneManager.CurrentScene.BasicScanCellAt(pos, ZLevel);

            if (View[pos.x, pos.y] != newCell)
            {
                DrawPixel(newCell, new Vector2Int(pos.x, pos.y), true);
                View[pos.x, pos.y] = newCell;
            }
        }


        // Drawing
        private static void DrawArea(CellScan[,] scan, Bound bound, bool erase)
        {
            for (int y = 0; y < scan.GetLength(1); y++)
            {
                for (int x = 0; x < scan.GetLength(0); x++)
                {
                    DrawPixel(scan[x, y], new Vector2Int(x, y) + bound.TopLeft, erase);
                }
            }
        }
        private static void DrawPixel(CellScan cellScan, Vector2Int screenPos, bool erase)
        {
            SetCursorPosition(screenPos + ScreenBound);
            
            SetCursorColor(cellScan.TopColor, cellScan.BottomColor);
            
            Console.Write(cellScan.Shape);
            
            RestCursor();
        }


        // Cursor Management
        private static void SetCursorColor(ConsoleColor topColor, ConsoleColor bottomColor)
        {
            Console.ForegroundColor = topColor;
            Console.BackgroundColor = bottomColor;
        }
        private static void RestCursor()
        {
            SetCursorPosition(CursorRestPosition);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private static void SetCursorPosition(Vector2Int pos)
        {
            Console.CursorLeft = pos.x * CellRenderSize.x;
            Console.CursorTop = pos.y * CellRenderSize.y;
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