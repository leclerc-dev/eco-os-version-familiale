using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;

namespace EcoPlusOS.UI.Elements
{
    public interface IDrawing
    {
        void Draw(UIEnvironment canvas, Point location, int width = 0, int height = 0);
    }
}
