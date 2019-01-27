using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Cosmos.System;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Core;
using EcoPlusOS.UI.Core.Interactivity;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public class EcoPlusLogo : UIElement
    {
        private readonly Pen _ecoPlusBackgroundPen = new Pen(Color.Blue);
        private static readonly EcoRand.EcoRandom Rand = EcoRand.Instance;

        public Color Background
        {
            get => _ecoPlusBackgroundPen.Color;
            set
            {
                if (_ecoPlusBackgroundPen.Color == value) return;
                _ecoPlusBackgroundPen.Color = value;
                Draw();
            }
        }

        protected override void DrawImplementation()
        {
            Environment.DrawFilledRectangle(_ecoPlusBackgroundPen, Location, Size.Width, Size.Height);
        }

        protected override bool TryDrawPartialImplementation(Rectangle bounds, Rectangle relativeBounds)
        {
            DrawingHelpers.DrawRectanglePartial(Environment, _ecoPlusBackgroundPen, bounds, relativeBounds);
            return true;
        }

        public EcoPlusLogo(UIEnvironment env) : this(env, new Point(0, 0), Color.Blue, Size.Empty)
        {
        }

        public EcoPlusLogo(UIEnvironment env, Point location, Color color = default, Size size = default) : base(env,
            location, size, false)
        {
            if (color != default) _ecoPlusBackgroundPen.Color = color;
            InputBindings.Add(new KeyBinding(ChangeColor, ConsoleKeyEx.C));
            Draw();
        }

        private void ChangeColor()
        {
            Background = Color.FromArgb(Rand.Next(0, 255), Rand.Next(0, 255), Rand.Next(0, 255));
        }
    }
}