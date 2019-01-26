using System.Drawing;
using System.Runtime.CompilerServices;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Core;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public class EcoPlusLogo : UIElement
    {
        private static readonly Pen EcoPlusBackgroundPen = new Pen(Color.Blue);
        protected override void DrawImplementation()
        {
            Environment.DrawFilledRectangle(EcoPlusBackgroundPen, Location, Size.Width, Size.Height);
        }
        public EcoPlusLogo(UIEnvironment env) : base(env)
        {
        }

        public EcoPlusLogo(UIEnvironment env, Point location, Size size = default) : base(env, location, size)
        {
        }
    }
}