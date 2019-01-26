using EcoPlusOS.UI.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using EcoPlusOS.UI.Core.Interactivity;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Core
{
    public delegate void ElementDrawnDelegate(UIElement element, Rectangle previousBounds);
    public abstract class UIElement : Drawing
    {
        public static ElementDrawnDelegate ElementDrawn { get; set; } = null;
        #region Constructors
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
        #endregion
        #region Drawing
        public sealed override void Draw(UIEnvironment env, Point location, Size size)
        {
            _location = location;
            _size = size;
            Draw();
        }
        public void Draw()
        {
            var e = EarlierRenderedBounds;
            DrawImplementation();
            LastRenderedBounds = GetRenderBounds();
            if (EnableEvent && ElementDrawn != null)
            {
                ElementDrawn(this, e);
            }
        }
        protected abstract void DrawImplementation();
        // private static readonly Size SafetyInflation = new Size(8, 8);
        public bool TryDrawPartial(Rectangle bounds)
        {
            //bounds.Inflate(SafetyInflation);
            //bounds.X -= SafetyInflation.Width / 2;
            //bounds.Y -= SafetyInflation.Height / 2;
            var calculated = bounds;
            var intersection = calculated.IntersectsWith(LastRenderedBounds);
            if (!intersection && !LastRenderedBounds.Contains(bounds)) return true; // yea everything went fine
            if (intersection)
            {
                calculated.Intersect(LastRenderedBounds);
            }
            calculated.X -= LastRenderedBounds.X;
            calculated.Y -= LastRenderedBounds.Y;
            if (calculated == Rectangle.Empty) return true; // yay who cares excs dee
            return TryDrawPartialImplementation(bounds, calculated);
        }

        protected virtual bool TryDrawPartialImplementation(Rectangle bounds, Rectangle relativeBounds)
        {
            return false;
        }
        #endregion
        #region Interactivity
        protected List<InputBinding> InputBindings { get; } = new List<InputBinding>();  
        public void TriggerEvents()
        {
            foreach (var t in InputBindings)
            {
                t.Process();
            }
        }
        #endregion
        #region Disabling

        public bool IsEnabled { get; private set; } = true;
        public void Disable()
        {
            IsEnabled = false;
            foreach (var binding in InputBindings)
            {
                binding.Enabled = false;
            }
            InputBindings.Clear();
        }
        #endregion
        #region Properties & data
        public static bool EnableEvent { get; set; } = true;
        public Rectangle EarlierRenderedBounds { get; set; }
        public Rectangle LastRenderedBounds { get; private set; }
        private Point _location;
        protected readonly UIEnvironment Environment;

        public Point Location
        {
            get => _location;
            set
            {
                EarlierRenderedBounds = GetRenderBounds();
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
                EarlierRenderedBounds = GetRenderBounds();
                _size = value; Draw();
            }
        }
        internal System.Drawing.Point SystemPointLocation => new System.Drawing.Point(Location.X, Location.Y);
        protected virtual Rectangle GetRenderBounds()
        {
            return new Rectangle(SystemPointLocation, Size);
        }
        public void SetLocationAndSize(Point p, Size s)
        {
            EarlierRenderedBounds = GetRenderBounds();
            _location = p;
            _size = s;
            Draw();
        }
        #endregion
    }

    //public static class UIElementEventsExtensions
    //{
    //    public static void Invoke(this DelegateAggregator<ElementDrawnDelegate> aggr, UIElement element)
    //    {
    //        aggr.Invoke(d => d(element));
    //    }
    //}
}