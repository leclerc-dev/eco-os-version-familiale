using System.Drawing;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Core
{
    public abstract class Drawing
    {
        public abstract void Draw(UIEnvironment canvas, Point location, Size size);
    }
}
