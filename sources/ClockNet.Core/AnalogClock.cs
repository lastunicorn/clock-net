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

        #region Event ShapeAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="Shapes"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the Shapes collection.")]
        public event EventHandler<ShapeAddedEventArgs> ShapeAdded;

        /// <summary>
        /// Raises the <see cref="ShapeAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnShapeAdded(ShapeAddedEventArgs e)
        {
            ShapeAdded?.Invoke(this, e);
        }

        #endregion

        #region Event ShapeRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="Shapes"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the Shapes collection.")]
        public event EventHandler<ShapeRemovedEventArgs> ShapeRemoved;

        /// <summary>
        /// Raises the <see cref="ShapeRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnShapeRemoved(ShapeRemovedEventArgs e)
        {
            ShapeRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event ShapesCleared

        /// <summary>
        /// Event raised when the Shapes collection is cleared.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the Shapes collection is cleared (all the shapes are removed).")]
        public event EventHandler ShapesCleared;

        /// <summary>
        /// Raises the <see cref="ShapesCleared"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnShapesCleared(EventArgs e)
        {
            ShapesCleared?.Invoke(this, e);
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

        #region Movement Property

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
                    movement.Tick -= HandleMovementTimeChanged;
                }

                movement = value;

                if (movement != null)
                {
                    movement.Tick += HandleMovementTimeChanged;
                    movement.Start();
                }

                Invalidate();

                OnMovementChanged(EventArgs.Empty);
            }
        }

        private void HandleMovementTimeChanged(object sender, TickEventArgs e)
        {
            time = e.Time;
            Invalidate();
        }

        #endregion

        #region Shapes Property

        /// <summary>
        /// The list of shapes that display the time.
        /// </summary>
        private ShapeCollection<IShape> shapes;

        /// <summary>
        /// Gets the list of shapes.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes.")]
        public ShapeCollection<IShape> Shapes => shapes;

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

            shapes = new ShapeCollection<IShape>();
            shapes.ShapeAdded += HandleShapeAdded;
            shapes.ShapeRemoved += HandleShapeRemoved;
            shapes.Cleared += HandleShapesCleared;

            DoubleBuffered = true;
            Size = new Size((int)diameter, (int)diameter);

            CalculateDimmensions();
        }

        private void HandleShapeAdded(object sender, ShapeAddedEventArgs e)
        {
            OnShapeAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleShapeRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnShapeRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleShapesCleared(object sender, EventArgs e)
        {
            OnShapesCleared(EventArgs.Empty);
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

            DrawShapes(g, centerMatrix);

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

        private void DrawShapes(Graphics g, Matrix initialMatrix)
        {
            ClockDrawingContext context = new ClockDrawingContext(g, Time, diameter);

            foreach (IShape shape in Shapes)
            {
                if (shape == null)
                    continue;

                g.Transform = initialMatrix;
                shape.Draw(context);
            }
        }

        /// <summary>
        /// Sets a new set of shapes to be used by the clock.
        /// </summary>
        /// <param name="clockTemplate">An instance of <see cref="TemplateBase"/> class containing the <see cref="IShape"/> instances.</param>
        public void ApplyTemplate(TemplateBase clockTemplate)
        {
            if (clockTemplate is null) throw new ArgumentNullException(nameof(clockTemplate));

            shapes.Clear();
            if (clockTemplate.Shapes != null)
            {
                foreach (IShape shape in clockTemplate.Shapes)
                    shapes.Add(shape);
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

                for (int i = shapes.Count - 1; i >= 0; i--)
                {
                    if (shapes[i] is IHand hand)
                    {
                        if (hand.HitTest(points[0], time))
                        {
                            Console.WriteLine("click: [{0} x {1}]; Shape: {2}", points[0].X, points[0].Y, hand.Name);
                            break;
                        }
                    }
                }

                base.OnMouseClick(e);
            }
        }

        public TemplateBase ExportTemplate()
        {
            Template template = new Template();
            template.Shapes.AddRange(Shapes);

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
                    movement.Tick -= HandleMovementTimeChanged;
                }

                foreach (IShape shape in shapes)
                    shape?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
