using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Elements;
using Console = System.Console;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI
{
    public class UIEnvironment : SVGAIIScreen
    {
        public void Disable() => SvgaDriver.Disable();
        private SvgaIIDriver SvgaDriver => (SvgaIIDriver) xSVGAIIDriver;       
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
            xSVGAIIDriver = new SvgaIIDriver();
            Mode = mode; // update mode with the thing OwO;
            Clear(Color.Bisque);
            EcoPlusLogo.Draw(this, new Point(10, 10), mode.Columns - 20, mode.Rows - 20);
            MouseManager.ScreenWidth = (uint)mode.Columns;
            MouseManager.ScreenHeight = (uint)mode.Rows;

            Start();
        }

        public void Start()
        {
            try
            {
                StartInternal();
            }
            catch (Exception)
            {
                Disable();
                throw;
            }
        }
        public void StartInternal()
        {
            while (true)
            {
                DrawMouse();
                HandleKeyboardEvents();
                if (!SvgaDriver.Enabled) break;
            }
        }

        private void HandleKeyboardEvents()
        {
            if (KeyboardManager.TryReadKey(out var k))
            {
                if (k.Key == ConsoleKeyEx.Escape)
                {
                    Disable();
                }
            }
        }

        private void DrawMouse()
        {
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

        private class SvgaIIDriver : VMWareSVGAII
        {
            public bool Enabled => ReadRegister(Register.Enable) == 1;
            public void Disable()
            {
                WriteRegister(Register.Enable, 0);
            }
        }
    }
}
