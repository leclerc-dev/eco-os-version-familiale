using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Elements;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI
{
    public class UIEnvironment : SVGAIIScreen
    {
        private static readonly IDrawing EcoPlusLogo = new EcoPlusLogo();
        private static readonly IDrawing MouseCursor = new MouseCursorDrawing(Color.Black);
        protected override Mode getDefaultGraphicMode()
        {
            return new Mode(320, 200, ColorDepth.ColorDepth32);
        }

        public UIEnvironment()
        {
            Initialize();
        }
        public UIEnvironment(Mode graphicsMode) : base(graphicsMode)
        {
            Initialize();
        }
        private void Initialize()
        {
            Clear(Color.Bisque);
            EcoPlusLogo.Draw(this, new Point(10, 10), mode.Columns - 20, mode.Rows - 20);
            MouseManager.ScreenHeight = (uint)mode.Columns;
            MouseManager.ScreenWidth = (uint)mode.Rows;
            Start();
        }

        public void Start()
        {
            while (true)
            {
                DrawMouse();
            }
        }

        private void DrawMouse()
        {
            Cosmos.System.Kernel.PrintDebug($"Mouse coords: x -> {MouseManager.X} ~|-|~ y -> {MouseManager.Y}");
            try
            {
                var point = new Point((int) Math.Max(2, MouseManager.X), (int) Math.Max(2, MouseManager.Y));
                MouseCursor.Draw(this, point, 2, 2);
            }
            catch (Exception e)
            {
                Cosmos.System.Kernel.PrintDebug($"something gone wrong in the mouse thingo: {e.Message}");
            }
        }
    }
}
