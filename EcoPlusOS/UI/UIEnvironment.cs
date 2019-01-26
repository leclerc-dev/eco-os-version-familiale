using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using EcoPlusOS.CustomLinq;
using EcoPlusOS.UI.Core;
using EcoPlusOS.UI.Elements;
using EcoPlusOS.UI.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
            UIElement.ElementDrawn = UIElementUpdated;
            Start();
        }

        private void UIElementUpdated(UIElement element, Rectangle previousBounds)
        {
            UIElement.EnableEvent = false;
            //var copy = new List<UIElement>();
            //int index = -1;
            //for (int i = 0; i < _elements.Count; i++)
            //{
            //    if (_elements[i] == element)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            //if (index == -1) goto fallback; // goto = éco+ code
            //for (int i = index; i < _elements.Count; i++)
            //{
            //    Kernel.PrintDebug("Skipping: " + i);
            //    copy.Add(_elements[i]);
            //}
            //copy = copy.CustomReverse();
            //foreach (var e in copy)
            //{
            //    e.Draw();
            //}
            // SOOON smth better TODO please ^^
            ProcessIntersections(element, previousBounds);
        fallback:
            UIElement.EnableEvent = true;
        }

        private void ProcessIntersections(UIElement element, Rectangle previousBounds, int startingIndex = 0)
        {
            var elementsSoFar = new List<UIElement>();
            for (var i = startingIndex; i < _elements.Count; i++)
            {
                var e = _elements[i];
                if (e == element)
                {
                    e.Draw();
                    continue;
                }
                var condition = e.LastRenderedBounds.IntersectsWith(element.LastRenderedBounds);
                foreach (var middleElement in elementsSoFar)
                {
                    if (condition) break;
                    condition = e.LastRenderedBounds.IntersectsWith(middleElement.LastRenderedBounds);
                }
                if (condition)
                {
                    elementsSoFar.Add(e);
                    if (!e.TryDrawPartial(previousBounds))
                        e.Draw();
                }
            }
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
