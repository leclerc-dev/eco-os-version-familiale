using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Core;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public sealed class MouseCursorElement : UIElement
    {
        private readonly Pen _pen = new Pen(Color.Black);

        public MouseCursorElement(UIEnvironment env, Color mouseColor, Point loc, Size size) : base(env, loc, size, true)
        {
            _pen.Color = mouseColor;
        }

        public MouseCursorElement(UIEnvironment env) : this(env, Color.Black, new Point(0, 0), new Size(2, 2))
        {
            
        }
        protected override void DrawImplementation()
        {
            try
            {
                Environment.DrawFilledRectangle(_pen, Location, Size.Width, Size.Height);
            }
            catch (Exception e)
            {
                Kernel.PrintDebug("Oh no my mousy " + e);
            }
        }

        protected override bool TryDrawPartialImplementation(Rectangle bounds, Rectangle relativeBounds)
        {
            DrawingHelpers.DrawRectanglePartial(Environment, _pen, bounds, relativeBounds);
            return true;
        }
    }
}