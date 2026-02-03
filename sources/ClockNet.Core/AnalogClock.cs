// ClockNet
// Copyright (C) 2010 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Movements;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// An Windows Forms control that displays an old style analog clock.
    /// </summary>
    /// <remarks>
    /// <para>If the compilation symbol "PERFORMANCE_INFO" is used at compile time, additional information about the
    /// time consumed with the <see cref="OnPaint"/> method are displayed in the upper left corner of the control.</para>
    /// <para>If the "PERFORMANCE_INFO" symbol is not used, the code necessary to colect performance information will
    /// not be compiled at all, so it will not influence the performance.</para>
    /// </remarks>
    [Designer(typeof(AnalogClockDesigner))]
    //[ToolboxBitmap(typeof(AnalogClock), "icon16.bmp")]
    public class AnalogClock : Control
    {
        #region Performance Info

#if PERFORMANCE_INFO

        // >> Needed to display performance info.
        private PerformanceInfo performanceInfo = new PerformanceInfo();

#endif

        #endregion

        #region Event MovementChanged

        /// <summary>
        /// Event raised when the value of the <see cref="Movement"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the Movement property is changed.")]
        public event EventHandler MovementChanged;

        /// <summary>
        /// Raises the <see cref="MovementChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnMovementChanged(EventArgs e)
        {
            MovementChanged?.Invoke(this, e);
        }

        #endregion

        #region Event BackgroundAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="Backgrounds"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the Backgrounds collection.")]
        public event EventHandler<ShapeAddedEventArgs> BackgroundAdded;

        /// <summary>
        /// Raises the <see cref="BackgroundAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnBackgroundAdded(ShapeAddedEventArgs e)
        {
            BackgroundAdded?.Invoke(this, e);
        }

        #endregion

        #region Event BackgroundRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="Backgrounds"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the Backgrounds collection.")]
        public event EventHandler<ShapeRemovedEventArgs> BackgroundRemoved;

        /// <summary>
        /// Raises the <see cref="BackgroundRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnBackgroundRemoved(ShapeRemovedEventArgs e)
        {
            BackgroundRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event BackgroundsCleared

        /// <summary>
        /// Event raised when the BackgroundShapes collection is cleared.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the Backgrounds collection is cleared (all the shapes are removed).")]
        public event EventHandler BackgroundsCleared;

        /// <summary>
        /// Raises the <see cref="BackgroundsCleared"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnBackgroundsCleared(EventArgs e)
        {
            BackgroundsCleared?.Invoke(this, e);
        }

        #endregion

        #region Event RimAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="Rims"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the Rims collection.")]
        public event EventHandler<ShapeAddedEventArgs> RimAdded;

        /// <summary>
        /// Raises the <see cref="RimAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnRimAdded(ShapeAddedEventArgs e)
        {
            RimAdded?.Invoke(this, e);
        }

        #endregion

        #region Event RimRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="Rims"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the Rims collection.")]
        public event EventHandler<ShapeRemovedEventArgs> RimRemoved;

        /// <summary>
        /// Raises the <see cref="RimRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnRimRemoved(ShapeRemovedEventArgs e)
        {
            RimRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event RimsCleared

        /// <summary>
        /// Event raised when the AngularShapes collection is cleared.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the Rims collection is cleared (all the shapes are removed).")]
        public event EventHandler RimsCleared;

        /// <summary>
        /// Raises the <see cref="RimsCleared"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnRimsCleared(EventArgs e)
        {
            RimsCleared?.Invoke(this, e);
        }

        #endregion

        #region Event HandShapeAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="Hands"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the HandShapes collection.")]
        public event EventHandler<ShapeAddedEventArgs> HandShapeAdded;

        /// <summary>
        /// Raises the <see cref="HandShapeAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnHandShapeAdded(ShapeAddedEventArgs e)
        {
            HandShapeAdded?.Invoke(this, e);
        }

        #endregion

        #region Event HandShapeRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="Hands"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the HandShapes collection.")]
        public event EventHandler<ShapeRemovedEventArgs> HandShapeRemoved;

        /// <summary>
        /// Raises the <see cref="HandShapeRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnHandShapeRemoved(ShapeRemovedEventArgs e)
        {
            HandShapeRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event HandShapeCleared

        /// <summary>
        /// Event raised when the HandShapes collection is cleared.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the HandShapes collection is cleared (all the shapes are removed).")]
        public event EventHandler HandShapeCleared;

        /// <summary>
        /// Raises the <see cref="HandShapeCleared"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnHandShapeCleared(EventArgs e)
        {
            HandShapeCleared?.Invoke(this, e);
        }

        #endregion

        #region Time Property

        /// <summary>
        /// The time displayed by the clock.
        /// </summary>
        private TimeSpan time;

        /// <summary>
        /// Gets or sets the time displayed by the clock.
        /// If the <see cref="Movement"/> property is set, this property is changed almost immetiately.
        /// </summary>
        [Category("Value")]
        [DefaultValue(typeof(TimeSpan), "0")]
        [Description("The time displayed by the clock.")]
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                Invalidate();
            }
        }

        #endregion

        #region Time Provider Property

        /// <summary>
        /// An instance of the <see cref="IMovement"/> that provides the time to be displayed by the timer.
        /// </summary>
        private IMovement movement;

        /// <summary>
        /// Gets or sets an instance of the <see cref="IMovement"/> that provides the time to be displayed by the timer.
        /// </summary>
        [Category("Value")]
        [DefaultValue(null)]
        [Description("Provides the time to be displayed by the timer.")]
        public IMovement Movement
        {
            get { return movement; }
            set
            {
                if (movement != null)
                {
                    movement.Stop();
                    movement.TimeChanged -= HandleMovementTimeChanged;
                }

                movement = value;

                if (movement != null)
                {
                    movement.TimeChanged += HandleMovementTimeChanged;
                    movement.Start();
                }

                Invalidate();

                OnMovementChanged(EventArgs.Empty);
            }
        }

        private void HandleMovementTimeChanged(object sender, TimeChangedEventArgs e)
        {
            time = e.Time;
            Invalidate();
        }

        #endregion

        #region Backgrounds Property

        /// <summary>
        /// The list of shapes that are drawn on the background of the clock.
        /// </summary>
        private ShapeCollection<IBackground> backgrounds;

        /// <summary>
        /// Gets the list of shapes that are drawn on the background of the clock.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that are drawn on the background of the clock.")]
        public ShapeCollection<IBackground> Backgrounds => backgrounds;

        #endregion

        #region Rims Property

        /// <summary>
        /// The list of shapes that are drawn repetitively on the edge of the clock.
        /// </summary>
        private ShapeCollection<IRim> rims;

        /// <summary>
        /// Gets the list of shapes that are drawn repetitively on the edge of the clock.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that are drawn repetitively on the edge of the clock.")]
        public ShapeCollection<IRim> Rims => rims;

        #endregion

        #region Hands Property

        /// <summary>
        /// The list of shapes that display the time.
        /// </summary>
        private ShapeCollection<IHand> hands;

        /// <summary>
        /// Gets the list of shapes that display the time.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that display the time.")]
        public ShapeCollection<IHand> Hands => hands;

        #endregion

        #region KeepProportions Property

        /// <summary>
        /// A value that specifies if the drawn clock should alwais keep its proportions inside the control's area.
        /// </summary>
        private bool keepProportions = true;

        /// <summary>
        /// Gets or sets a value that specifies if the drawn clock should alwais keep its proportions inside the control's area.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(true)]
        [Description("A value that specifies if the drawn clock should alwais keep its proportions inside the control's area.")]
        public bool KeepProportions
        {
            get => keepProportions;
            set
            {
                keepProportions = value;
                CalculateDimmensions();
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalogClock"/> class with
        /// default aspect of the interface.
        /// </summary>
        public AnalogClock()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            backgrounds = new ShapeCollection<IBackground>();
            backgrounds.ShapeAdded += HandleBackgroundAdded;
            backgrounds.ShapeRemoved += HandleBackgroundRemoved;
            backgrounds.Cleared += HandleBackgroundsCleared;

            rims = new ShapeCollection<IRim>();
            rims.ShapeAdded += HandleRimAdded;
            rims.ShapeRemoved += HandleRimRemoved;
            rims.Cleared += HandleRimsCleared;

            hands = new ShapeCollection<IHand>();
            hands.ShapeAdded += HandleHandAdded;
            hands.ShapeRemoved += HandleHandRemoved;
            hands.Cleared += HandleHandsCleared;

            DoubleBuffered = true;
            Size = new Size((int)diameter, (int)diameter);

            CalculateDimmensions();
        }

        private void HandleBackgroundAdded(object sender, ShapeAddedEventArgs e)
        {
            OnBackgroundAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleBackgroundRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnBackgroundRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleBackgroundsCleared(object sender, EventArgs e)
        {
            OnBackgroundsCleared(EventArgs.Empty);
            Invalidate();
        }

        private void HandleRimAdded(object sender, ShapeAddedEventArgs e)
        {
            OnRimAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleRimRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnRimRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleRimsCleared(object sender, EventArgs e)
        {
            OnRimsCleared(EventArgs.Empty);
            Invalidate();
        }

        private void HandleHandAdded(object sender, ShapeAddedEventArgs e)
        {
            OnHandShapeAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleHandRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnHandShapeRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleHandsCleared(object sender, EventArgs e)
        {
            OnHandShapeCleared(EventArgs.Empty);
            Invalidate();
        }

        private void HandleShapeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }


        #region Calculated Dimensions

        /// <summary>
        /// The calculated diameter of the clock.
        /// </summary>
        private float diameter = 200f;

        /// <summary>
        /// The calculated radius of the clock.
        /// </summary>
        private float radius;

        /// <summary>
        /// The calculated x coordinate of the center of the clock.
        /// </summary>
        private float centerX;

        /// <summary>
        /// The calculated y coordinate of the center of the clock.
        /// </summary>
        private float centerY;

        /// <summary>
        /// The value with which the clock shoud be scaled on the x axis.
        /// </summary>
        private float scaleX;

        /// <summary>
        /// The value with which the clock shoud be scaled on the y axis.
        /// </summary>
        private float scaleY;

        /// <summary>
        /// Calculates some dimension values needed by <see cref="OnPaint"/> method that changes only
        /// when the physical dimensions are changed and are not influenced by the value displayed in the control.
        /// </summary>
        private void CalculateDimmensions()
        {
            float drawableWidth = ClientSize.Width - Padding.Left - Padding.Right;
            float drawableHeight = ClientSize.Height - Padding.Top - Padding.Bottom;

            if (drawableWidth < 0 || drawableHeight < 0)
            {
                radius = 0;
            }
            else
            {
                if (keepProportions)
                {
                    if (drawableWidth < drawableHeight)
                    {
                        scaleX = drawableWidth / diameter;
                        scaleY = drawableWidth / diameter;
                    }
                    else if (drawableWidth > drawableHeight)
                    {
                        scaleX = drawableHeight / diameter;
                        scaleY = drawableHeight / diameter;
                    }
                    else
                    {
                        scaleX = drawableWidth / diameter;
                        scaleY = drawableHeight / diameter;
                    }
                }
                else
                {
                    scaleX = drawableWidth / diameter;
                    scaleY = drawableHeight / diameter;
                }

                radius = diameter / 2;
                centerX = Padding.Left + drawableWidth / 2;
                centerY = Padding.Top + drawableHeight / 2;
            }
        }

        #endregion


        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.PaddingChanged"/> event and repaints the clock.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            CalculateDimmensions();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.Resize"/> event and repaints the clock.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            CalculateDimmensions();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.Paint"/> event and paints the clock.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {

#if PERFORMANCE_INFO

            performanceInfo.Start();
#endif

            base.OnPaint(e);

            if (radius <= 0)
                return;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Matrix originalMatrix = e.Graphics.Transform;

            g.TranslateTransform(centerX, centerY);
            g.ScaleTransform(scaleX, scaleY);
            Matrix centerMatrix = e.Graphics.Transform;

            DrawBackgroundShapes(g, centerMatrix);
            DrawRimShapes(g, centerMatrix);
            DrawHandShapes(g, centerMatrix);

#if PERFORMANCE_INFO

            performanceInfo.Stop();

            g.Transform = originalMatrix;
            using (Font performanceTestFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
            {
                string text = performanceInfo.ToString();
                g.DrawString(text, performanceTestFont, Brushes.Black, 0, 0);
            }

#endif

        }

        private void DrawBackgroundShapes(Graphics g, Matrix initialMatrix)
        {
            IEnumerable<IBackground> backgroundShapesNotNull = backgrounds
                .Where(x => x != null);

            ClockDrawingContext context = new ClockDrawingContext(g, Time);

            foreach (IBackground backgroundShape in backgroundShapesNotNull)
            {
                g.Transform = initialMatrix;
                backgroundShape.Draw(context);
            }
        }

        private void DrawRimShapes(Graphics g, Matrix initialMatrix)
        {
            IEnumerable<IRim> angularShapesNotNull = rims
                .Where(x => x != null);

            ClockDrawingContext context = new ClockDrawingContext(g, Time);

            foreach (IRim angularShape in angularShapesNotNull)
            {
                g.Transform = initialMatrix;
                angularShape.Draw(context);
            }
        }

        private void DrawHandShapes(Graphics g, Matrix initialMatrix)
        {
            IEnumerable<IHand> handShapesNotNull = hands
                .Where(x => x != null);

            ClockDrawingContext context = new ClockDrawingContext(g, Time);

            foreach (IHand handShape in handShapesNotNull)
            {
                g.Transform = initialMatrix;

                handShape.Draw(context);
            }
        }

        /// <summary>
        /// Sets a new set of shapes to be used by the clock.
        /// </summary>
        /// <param name="clockTemplate">An instance of <see cref="TemplateBase"/> class containing the <see cref="IShape"/> instances.</param>
        public void ApplyTemplate(TemplateBase clockTemplate)
        {
            if (clockTemplate is null) throw new ArgumentNullException(nameof(clockTemplate));

            backgrounds.Clear();
            if (clockTemplate.Backgrounds != null)
            {
                foreach (IBackground shape in clockTemplate.Backgrounds)
                    backgrounds.Add(shape);
            }

            rims.Clear();
            if (clockTemplate.Rims != null)
            {
                foreach (IRim shape in clockTemplate.Rims)
                    rims.Add(shape);
            }

            hands.Clear();
            if (clockTemplate.Hands != null)
            {
                foreach (IHand shape in clockTemplate.Hands)
                    hands.Add(shape);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            using (Matrix matrix = new Matrix())
            {
                matrix.Translate(-centerX, -centerY);
                matrix.Scale(1 / scaleX, 1 / scaleY, MatrixOrder.Append);

                PointF[] points = new PointF[] { e.Location };
                matrix.TransformPoints(points);
                PointF clickLocation = points[0];

                for (int i = hands.Count - 1; i >= 0; i--)
                {
                    if (hands[i].HitTest(points[0], time))
                    {
                        Console.WriteLine("click: [{0} x {1}]; Shape: {2}", points[0].X, points[0].Y, hands[i].Name);
                        break;
                    }
                }

                base.OnMouseClick(e);
            }
        }

        public TemplateBase ExportTemplate()
        {
            Template template = new Template();

            template.Backgrounds.AddRange(Backgrounds);
            template.Rims.AddRange(Rims);
            template.Hands.AddRange(Hands);

            return template;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (movement != null)
                {
                    movement.Stop();
                    movement.TimeChanged -= HandleMovementTimeChanged;
                }

                foreach (IBackground shape in backgrounds)
                    shape?.Dispose();

                foreach (IRim shape in rims)
                    shape?.Dispose();

                foreach (IHand shape in hands)
                    shape?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
