using EcoPlusOS.UI.Elements;
using System;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Core
{
    public delegate void ElementDrawnDelegate(UIElement element);
    public abstract class UIElement : Drawing
    {
        public static DelegateAggregator<ElementDrawnDelegate> _elementDrawn = new DelegateAggregator<ElementDrawnDelegate>();
        public static bool EnableEvent { get; set; } = true;
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

        public static DelegateAggregator<ElementDrawnDelegate> ElementDrawn
        {
            get => _elementDrawn;
            set { /* no */ }
        }

        public bool IsDirty;
        protected readonly UIEnvironment Environment;

        protected UIElement(UIEnvironment env, Point location, Size size, bool drawInCtor)
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
            DrawImplementation();
            if (EnableEvent)
                ElementDrawn.Invoke(this);
        }
        protected abstract void DrawImplementation();
        public sealed override bool HitTest(Point requested, Point currentLocation, Size size)
        {
            return HitTest(requested);
        }

        protected virtual bool HitTest(Point request)
        {
            return false;
        }
    }

    public static class UIElementEventsExtensions
    {
        public static void Invoke(this DelegateAggregator<ElementDrawnDelegate> aggr, UIElement element)
        {
            aggr.Invoke(d => d(element));
        }
    }
}