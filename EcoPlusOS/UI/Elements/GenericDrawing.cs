using System.Drawing;
using EcoPlusOS.UI.Core;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public class GenericDrawing<T> : UIElement where T : Drawing
    {
        private readonly T _drawing;
        public GenericDrawing(UIEnvironment env, T drawing) : base(env)
        {
            _drawing = drawing;
        }

        public GenericDrawing(UIEnvironment env, T drawing, Point location, Size size = default) : base(env, location, size)
        {
            _drawing = drawing;
        }
        protected override void DrawImplementation()
        {
            _drawing.Draw(Environment, Location, Size);
        }
    }
}