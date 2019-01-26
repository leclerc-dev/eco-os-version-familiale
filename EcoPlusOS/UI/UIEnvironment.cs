﻿using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Core;
using EcoPlusOS.UI.Elements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using EcoPlusOS.CustomLinq;
using EcoPlusOS.UI.Internal;
using Console = System.Console;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS
{
}

namespace EcoPlusOS.UI
{
#if VMWare
    public class UIEnvironment : SVGAIIScreen
#elif VBE
    public class UIEnvironment : CustomVbeScreen
#endif
    {
        public void Disable()
        {
            Driver.Disable();
        }
#if VMWare
        private SvgaIIDriver Driver => (SvgaIIDriver)xSVGAIIDriver;
#endif
        private MouseCursorElement _mouseCursor = null;
        //private static readonly Drawing EcoChanWallpaper = new EcoChanWallpaperDrawing();
        protected override Mode getDefaultGraphicMode()
        {
            return new Mode(320, 240, ColorDepth.ColorDepth32);
        }

        public UIEnvironment()
        {
            Initialize();
        }
        public UIEnvironment(Mode graphicsMode) : base(graphicsMode)
        {
            Initialize();
        }

        private List<UIElement> _elements = new List<UIElement>();
        private void Initialize()
        {
#if VMWare
            xSVGAIIDriver = new SvgaIIDriver();
#endif
            Mode = mode; // update mode with the thing OwO;
            Clear(Color.Bisque);
            _elements.Add(new EcoPlusLogo(this, new Point(10, 10), new Size(mode.Columns - 20, mode.Rows - 20)));
            Kernel.PrintDebug("Eco+ yes");
            _elements.Add(new ElPuebloDrawing(this, new Point(100, 55), Size.Empty));
            Kernel.PrintDebug("El pueblo yes");
            _mouseCursor = new MouseCursorElement(this);
            Kernel.PrintDebug("Mouse YESSS");
            _elements.Add(_mouseCursor);
            //ElPueblo.Draw(this, new Point(100, 55));
            MouseManagerEx.SetDimensions(mode);
            UIElement.ElementDrawn += UIElementUpdated;
            Start();
        }

        private void UIElementUpdated(UIElement element)
        {
            UIElement.EnableEvent = false;
            for (int i = _elements.Count - 1; i <= _elements.CustomIndexOf(element); i--)
            {
                var current = _elements[i];
                current.Draw();
            }
            UIElement.EnableEvent = true;
        }

        #region Startup
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
                if (!Driver.Enabled)
                {
#if !VMWare
                    // Clean up
                    VGAScreen.SetTextMode(VGAScreen.TextSize.Size80x25);
                    Console.Clear();
#endif
                    break;
                }
            }
        }
        #endregion
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
                _mouseCursor.Location = MouseManagerEx.ToPoint();
            }
            catch (Exception e)
            {
                Cosmos.System.Kernel.PrintDebug($"something gone wrong in the mouse thingo: {e.Message}");
            }
        }
#if VMWare
        private class SvgaIIDriver : VMWareSVGAII
        {
            public bool Enabled => ReadRegister(Register.Enable) == 1;
            public void Disable()
            {
                WriteRegister(Register.Enable, 0);
            }
        }
#endif
    }
}

namespace EcoPlusOS.UI.Internal
{
    // :3
}
