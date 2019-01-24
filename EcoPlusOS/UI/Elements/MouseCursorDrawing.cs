using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Cosmos.System.Graphics;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public class MouseCursorDrawing : IDrawing
    {
        private readonly Pen _pen;
        public MouseCursorDrawing(Color mouseColor)
        {
            _pen = new Pen(mouseColor, 2);
        }

        public MouseCursorDrawing() : this(Color.Black)
        {
            
        }
        public void Draw(UIEnvironment canvas, Point location, int width = 2, int height = 2)
        {
            if (width == 0) width = 2;
            if (height == 0) height = 2;
            canvas.DrawCircle(_pen, location, Math.Max(width, height));
        }
    }
}