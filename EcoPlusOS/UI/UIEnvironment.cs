using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using EcoPlusOS.CustomLinq;
using EcoPlusOS.UI.Core;
using EcoPlusOS.UI.Core.Interactivity;
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
using Global = Cosmos.HAL.Global;
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
            _elements.Add(new EcoPlusLogo(this, new Point(0, 0), size: new Size(mode.Columns, mode.Rows)));
            _elements.Add(new ElPueblo(this, new Point(100, 55)));
            _mouseCursor = new MouseCursorElement(this);
            _elements.Add(_mouseCursor);
            //ElPueblo.Draw(this, new Point(100, 55));
            MouseManagerEx.SetDimensions(mode);
            UIElement.ElementDrawn = UIElementUpdated;
            Start();
        }

        private void UIElementUpdated(UIElement element, Rectangle previousBounds)
        {
            if (!UIElement.EnableEvent) return;
            UIElement.EnableEvent = false;
            ProcessIntersections(in element, previousBounds);
            UIElement.EnableEvent = true;
        }
        // TODO children UIElements
        private void ProcessIntersections(in UIElement element, Rectangle previousBounds, int startingIndex = 0)
        {
            var areInFront = false;
            for (var i = startingIndex; i < _elements.Count; i++)
            {
                var e = _elements[i];
                if (e == element)
                {
                    e.Draw();
                    areInFront = true;
                    continue;
                }
                var condition = NeedsRendering(element, previousBounds, e);
                for (var j = 0; j < i; j++)
                {
                    if (condition) break;
                    var previous = _elements[j];
                    condition = NeedsRendering(previous, previousBounds, e);
                }
                if (condition)
                {
                    Kernel.PrintDebug("prev: " + previousBounds);
                    if (areInFront || !e.TryDrawPartial(previousBounds))
                        e.Draw();
                }
            }
        }

        private static bool NeedsRendering(UIElement element, Rectangle previousBounds, UIElement e)
        {
            return e.LastRenderedBounds.IntersectsWith(element.LastRenderedBounds)
                   || e.LastRenderedBounds.Contains(element.LastRenderedBounds)
                   || e.LastRenderedBounds.IntersectsWith(previousBounds)
                   || e.LastRenderedBounds.Contains(previousBounds);
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
        private void StartInternal()
        {
            while (true)
            {
                KeyBinding.UpdateKey();
                DisableOnEscapePress();
                HandleUIElementEvents();
                DrawMouse();
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

        private void DisableOnEscapePress()
        {
            if (KeyBinding.LastEvent?.Key == ConsoleKeyEx.Escape)
            {
                Disable();
            }
        }

        #endregion

        private void DrawMouse()
        {
            try
            {
                var location = MouseManagerEx.ToPoint();
                if  (_mouseCursor.Location.X - 1 <= location.X
                    && _mouseCursor.Location.X + 1 >= location.X                                                             
                    && _mouseCursor.Location.Y - 1 <= location.Y                                                              
                    && _mouseCursor.Location.Y + 1 >= location.Y) // error margin 1
                {
                    return;
                }
                _mouseCursor.Location = location;
            }
            catch (Exception e)
            {
                Cosmos.System.Kernel.PrintDebug($"something gone wrong in the mouse thingo: {e.Message}");
            }
        }

        private void HandleUIElementEvents()
        {
            foreach (var element in _elements)
            {
                element.TriggerEvents();
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
