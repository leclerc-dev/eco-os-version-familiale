using EcoPlusOS.UI.Elements;
using System;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Core
{
    public delegate void ElementDrawnDelegate(UIElement element, Rectangle previousBounds);
    public abstract class UIElement : Drawing
    {
        public static bool EnableEvent { get; set; } = true;
        public Rectangle LastRenderedBounds { get; private set; }
        private Point _location;

        public Point Location
        {
            get => _location;
            set
            {
                if (_location.X == value.X && Location.Y == value.Y) return;
                _location = value; Draw();
            }
        }
        private Size _size;

        public virtual Size Size
        {
            get => _size;
            set
            {
                if (_size == value) return;
                _size = value; Draw();
            }
        }

        public static ElementDrawnDelegate ElementDrawn { get; set; } = null;

        public bool IsDirty;
        protected readonly UIEnvironment Environment;

        protected UIElement(UIEnvironment env, Point location, Size size, bool drawInCtor = true)
        {
            Environment = env;
            _location = location;
            _size = size;
            if (drawInCtor)
                Draw();
        }
        public UIElement(UIEnvironment env, Point location, Size size) : this(env, location, size, true) { }

        public UIElement(UIEnvironment env) : this(env, new Point(0, 0), Size.Empty) { }
        public sealed override void Draw(UIEnvironment env, Point location, Size size)
        {
            _location = location;
            _size = size;
            Draw();
        }

        public void SetLocationAndSize(Point p, Size s)
        {
            _location = p;
            _size = s;
            Draw();
        }

        public void Draw()
        {
            var previous = GetRenderBounds();
            DrawImplementation();
            LastRenderedBounds = GetRenderBounds();
            if (EnableEvent && ElementDrawn != null)
            {
                ElementDrawn(this, previous);
            }
        }

        protected System.Drawing.Point SystemPointLocation => new System.Drawing.Point(Location.X, Location.Y);
        protected virtual Rectangle GetRenderBounds() => new Rectangle(SystemPointLocation, Size);
        protected abstract void DrawImplementation();
    }

    //public static class UIElementEventsExtensions
    //{
    //    public static void Invoke(this DelegateAggregator<ElementDrawnDelegate> aggr, UIElement element)
    //    {
    //        aggr.Invoke(d => d(element));
    //    }
    //}
}