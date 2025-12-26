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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.TimeProviders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
        #region Event TimeProviderChanged

        /// <summary>
        /// Event raised when the value of the <see cref="TimeProvider"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the TimeProvider property is changed.")]
        public event EventHandler TimeProviderChanged;

        /// <summary>
        /// Raises the <see cref="TimeProviderChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnTimeProviderChanged(EventArgs e)
        {
            TimeProviderChanged?.Invoke(this, e);
        }

        #endregion

        #region Event BackgroundShapeAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="BackgroundShapes"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the BackgroundShapes collection.")]
        public event EventHandler<ShapeAddedEventArgs> BackgroundShapeAdded;

        /// <summary>
        /// Raises the <see cref="BackgroundShapeAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnBackgroundShapeAdded(ShapeAddedEventArgs e)
        {
            BackgroundShapeAdded?.Invoke(this, e);
        }

        #endregion

        #region Event BackgroundShapeRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="BackgroundShapes"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the BackgroundShapes collection.")]
        public event EventHandler<ShapeRemovedEventArgs> BackgroundShapeRemoved;

        /// <summary>
        /// Raises the <see cref="BackgroundShapeRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnBackgroundShapeRemoved(ShapeRemovedEventArgs e)
        {
            BackgroundShapeRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event BackgroundShapeCleared

        /// <summary>
        /// Event raised when the BackgroundShapes collection is cleared.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the BackgroundShapes collection is cleared (all the shapes are removed).")]
        public event EventHandler BackgroundShapeCleared;

        /// <summary>
        /// Raises the <see cref="BackgroundShapeCleared"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnBackgroundShapeCleared(EventArgs e)
        {
            BackgroundShapeCleared?.Invoke(this, e);
        }

        #endregion

        #region Event AngularShapeAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="AngularShapes"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is added to the AngularShapes collection.")]
        public event EventHandler<ShapeAddedEventArgs> AngularShapeAdded;

        /// <summary>
        /// Raises the <see cref="AngularShapeAdded"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnAngularShapeAdded(ShapeAddedEventArgs e)
        {
            AngularShapeAdded?.Invoke(this, e);
        }

        #endregion

        #region Event AngularShapeRemoved

        /// <summary>
        /// Event raised when a Shape is removed from the <see cref="AngularShapes"/> collection.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when a Shape is removed from the AngularShapes collection.")]
        public event EventHandler<ShapeRemovedEventArgs> AngularShapeRemoved;

        /// <summary>
        /// Raises the <see cref="AngularShapeRemoved"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnAngularShapeRemoved(ShapeRemovedEventArgs e)
        {
            AngularShapeRemoved?.Invoke(this, e);
        }

        #endregion

        #region Event AngularShapeCleared

        /// <summary>
        /// Event raised when the AngularShapes collection is cleared.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the AngularShapes collection is cleared (all the shapes are removed).")]
        public event EventHandler AngularShapeCleared;

        /// <summary>
        /// Raises the <see cref="AngularShapeCleared"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnAngularShapeCleared(EventArgs e)
        {
            AngularShapeCleared?.Invoke(this, e);
        }

        #endregion

        #region Event HandShapeAdded

        /// <summary>
        /// Event raised when a Shape is added to the <see cref="HandShapes"/> collection.
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
        /// Event raised when a Shape is removed from the <see cref="HandShapes"/> collection.
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

        #region Time

        /// <summary>
        /// The time displayed by the clock.
        /// </summary>
        private TimeSpan time;

        /// <summary>
        /// Gets or sets the time displayed by the clock.
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

        /// <summary>
        /// The offset time used to decalate the displayed utc time.
        /// </summary>
        private TimeSpan? utcOffset;

        /// <summary>
        /// Gets or sets the offset time used to decalate the displayed utc time.
        /// If the value is null, the local time is displayed.
        /// To display the UTC time, set this property to zero.
        /// </summary>
        [DefaultValue(null)]
        [Category("Value")]
        [Description("Specifies the offset time used to decalate the displayed utc time.")]
        [TypeConverter(typeof(NullableTimeSpanConverter))]
        [EditorAttribute(typeof(TimeSpanEditor), typeof(UITypeEditor))]
        public TimeSpan? UtcOffset
        {
            get { return utcOffset; }
            set
            {
                utcOffset = value;
                if (timeProvider == null)
                    Invalidate();
            }
        }

        #endregion

        #region Timer

        /// <summary>
        /// The <see cref="System.Windows.Forms.Timer"/> used to automatically update the control with the time retrieved from the time provider.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Gets or sets the <see cref="System.Windows.Forms.Timer"/> used to automatically update the control with the time retrieved from the time provider.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(null)]
        [Description("The timer used to automatically update the control with the time retrieved from the time provider.")]
        public Timer Timer
        {
            get { return timer; }
            set
            {
                if (timer != null)
                    timer.Tick -= new EventHandler(timer_Tick);

                timer = value;

                if (timer != null)
                {
                    UpdateTime();
                    Invalidate();

                    timer.Tick += new EventHandler(timer_Tick);
                }
            }
        }

        /// <summary>
        /// Call-back function called by the timer when the time elapsed. The clock is updated with a new time from the time provider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
            Invalidate();
        }

        /// <summary>
        /// Updates the <see cref="Time"/> value with the one obtained from the <see cref="TimeProvider"/>
        /// (if  one is provided) or obtained using internal mechanism if no <see cref="TimeProvider"/> exists.
        /// </summary>
        private void UpdateTime()
        {
            if (timeProvider != null)
            {
                time = timeProvider.GetTime();
            }
            else if (utcOffset == null)
            {
                time = DateTime.Now.TimeOfDay;
            }
            else
            {
                time = DateTime.UtcNow.TimeOfDay.Add(utcOffset.Value);
            }
        }

        #endregion

        #region Time Provider

        /// <summary>
        /// An instance of the <see cref="ITimeProvider"/> that provides the time to be displayed by the timer.
        /// </summary>
        private ITimeProvider timeProvider;

        /// <summary>
        /// Gets or sets an instance of the <see cref="ITimeProvider"/> that provides the time to be displayed by the timer.
        /// </summary>
        [Category("Value")]
        [DefaultValue(null)]
        [Description("Provides the time to be displayed by the timer.")]
        public ITimeProvider TimeProvider
        {
            get { return timeProvider; }
            set
            {
                if (timeProvider != null)
                    timeProvider.Changed -= new EventHandler(timeProvider_Changed);

                timeProvider = value;

                if (timeProvider != null)
                    timeProvider.Changed += new EventHandler(timeProvider_Changed);

                Invalidate();

                OnTimeProviderChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region BackgroundShapes

        /// <summary>
        /// The list of shapes that are drawn on the background of the clock.
        /// </summary>
        private ShapeCollection<IBackground> backgroundShapes;

        /// <summary>
        /// Gets the list of shapes that are drawn on the background of the clock.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that are drawn on the background of the clock.")]
        public ShapeCollection<IBackground> BackgroundShapes => backgroundShapes;

        #endregion

        #region AngularShapes

        /// <summary>
        /// The list of shapes that are drawn repetitively on the edge of the clock.
        /// </summary>
        private ShapeCollection<IRimMarker> angularShapes;

        /// <summary>
        /// Gets the list of shapes that are drawn repetitively on the edge of the clock.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that are drawn repetitively on the edge of the clock.")]
        public ShapeCollection<IRimMarker> AngularShapes => angularShapes;

        #endregion

        #region HandShapes

        /// <summary>
        /// The list of shapes that display the time.
        /// </summary>
        private ShapeCollection<IHand> handShapes;

        /// <summary>
        /// Gets the list of shapes that display the time.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that display the time.")]
        public ShapeCollection<IHand> HandShapes => handShapes;

        #endregion


        #region Layout

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


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalogClock"/> class with
        /// default aspect of the interface.
        /// </summary>
        public AnalogClock()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalogClock"/> class with
        /// a set of shapes and a time provider.
        /// </summary>
        /// <param name="clockTemplate">An <see cref="ClockTemplate"/> object containing the shapes that creats the interface.</param>
        /// <param name="timeProvider">An instance of the <see cref="ITimeProvider"/> that provides the time to be displayed in the control.</param>
        public AnalogClock(ClockTemplate clockTemplate, ITimeProvider timeProvider)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);

            backgroundShapes = new ShapeCollection<IBackground>();
            backgroundShapes.ShapeAdded += HandleGroundShapeAdded;
            backgroundShapes.ShapeRemoved += HandleGroundShapeRemoved;
            backgroundShapes.Cleared += HandleGroundShapeCleared;

            angularShapes = new ShapeCollection<IRimMarker>();
            angularShapes.ShapeAdded += HandleAngularShapeAdded;
            angularShapes.ShapeRemoved += HandleAngularShapeRemoved;
            angularShapes.Cleared += HandleAngularShapeCleared;

            handShapes = new ShapeCollection<IHand>();
            handShapes.ShapeAdded += HandleHandShapeAdded;
            handShapes.ShapeRemoved += HandleHandShapeRemoved;
            handShapes.Cleared += HandleHandShapeCleared;

            if (clockTemplate != null)
                ApplyTemplate(clockTemplate);

            if (timeProvider != null)
            {
                this.timeProvider = timeProvider;
                this.timeProvider.Changed += new EventHandler(timeProvider_Changed);
            }

            DoubleBuffered = true;
            Text = "Dust in the Wind";
            Size = new Size((int)diameter, (int)diameter);

            CalculateDimmensions();
        }

        #endregion

        private void HandleGroundShapeAdded(object sender, ShapeAddedEventArgs e)
        {
            OnBackgroundShapeAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleGroundShapeRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnBackgroundShapeRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleGroundShapeCleared(object sender, EventArgs e)
        {
            OnBackgroundShapeCleared(EventArgs.Empty);
            Invalidate();
        }

        private void HandleAngularShapeAdded(object sender, ShapeAddedEventArgs e)
        {
            OnAngularShapeAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleAngularShapeRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnAngularShapeRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleAngularShapeCleared(object sender, EventArgs e)
        {
            OnAngularShapeCleared(EventArgs.Empty);
            Invalidate();
        }

        private void HandleHandShapeAdded(object sender, ShapeAddedEventArgs e)
        {
            OnHandShapeAdded(new ShapeAddedEventArgs(e.Index, e.Shape));

            e.Shape.Changed += new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleHandShapeRemoved(object sender, ShapeRemovedEventArgs e)
        {
            OnHandShapeRemoved(new ShapeRemovedEventArgs(e.Shape));

            e.Shape.Changed -= new EventHandler(HandleShapeChanged);
            Invalidate();
        }

        private void HandleHandShapeCleared(object sender, EventArgs e)
        {
            OnHandShapeCleared(EventArgs.Empty);
            Invalidate();
        }

        private void HandleShapeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(sender.GetType().ToString());
            Invalidate();
        }

        private void timeProvider_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }


        #region Calculated Dimensions

        /// <summary>
        /// The calculated diameter of the clock.
        /// </summary>
        private float diameter = 100f;

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

        #region Performance Info

#if PERFORMANCE_INFO

        // >> Needed to display performance info.
        private PerformanceInfo performanceInfo = new PerformanceInfo();

#endif

        #endregion

        #region OnPaint

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
            DrawAngularShapes(g, centerMatrix);
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
            IEnumerable<IBackground> backgroundShapesNotNull = backgroundShapes
                .Where(x => x != null);

            foreach (IBackground backgroundShape in backgroundShapesNotNull)
            {
                g.Transform = initialMatrix;
                backgroundShape.Draw(g);
            }
        }

        private void DrawAngularShapes(Graphics g, Matrix initialMatrix)
        {
            IEnumerable<IRimMarker> angularShapesNotNull = angularShapes
                .Where(x => x != null);

            foreach (IRimMarker angularShape in angularShapesNotNull)
            {
                angularShape.Reset();

                if (angularShape.Repeat)
                {
                    for (float i = 0; i <= 360; i += angularShape.Angle)
                    {
                        g.Transform = initialMatrix;
                        g.RotateTransform(i);
                        g.TranslateTransform(0f, -radius);

                        angularShape.Draw(g);
                    }
                }
                else if (angularShape.Index == 0)
                {
                    g.Transform = initialMatrix;
                    g.RotateTransform(angularShape.Angle);
                    g.TranslateTransform(0f, -radius);

                    angularShape.Draw(g);
                }
            }
        }

        private void DrawHandShapes(Graphics g, Matrix initialMatrix)
        {
            IEnumerable<IHand> handShapesNotNull = handShapes
                .Where(x => x != null);

            foreach (IHand handShape in handShapesNotNull)
            {
                g.Transform = initialMatrix;

                handShape.Time = time;
                handShape.Draw(g);
            }
        }

        #endregion

        /// <summary>
        /// Sets a new set of shapes to be used by the clock.
        /// </summary>
        /// <param name="clockTemplate">An instance of <see cref="ClockTemplate"/> class containing the <see cref="IShape"/> instances.</param>
        public void ApplyTemplate(ClockTemplate clockTemplate)
        {
            if (clockTemplate is null) throw new ArgumentNullException(nameof(clockTemplate));

            backgroundShapes.Clear();
            if (clockTemplate.BackgroundShapes != null)
            {
                foreach (IBackground shape in clockTemplate.BackgroundShapes)
                    backgroundShapes.Add(shape);
            }

            angularShapes.Clear();
            if (clockTemplate.AngularShapes != null)
            {
                foreach (IRimMarker shape in clockTemplate.AngularShapes)
                    angularShapes.Add(shape);
            }

            handShapes.Clear();
            if (clockTemplate.HandShapes != null)
            {
                foreach (IHand shape in clockTemplate.HandShapes)
                    handShapes.Add(shape);
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

                for (int i = handShapes.Count - 1; i >= 0; i--)
                {
                    if (handShapes[i].HitTest(points[0]))
                    {
                        Console.WriteLine("click: [{0} x {1}]; Shape: {2}", points[0].X, points[0].Y, handShapes[i].Name);
                        break;
                    }
                }

                base.OnMouseClick(e);
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (IBackground shape in backgroundShapes)
                    shape?.Dispose();

                foreach (IRimMarker shape in angularShapes)
                    shape?.Dispose();

                foreach (IHand shape in handShapes)
                    shape?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
