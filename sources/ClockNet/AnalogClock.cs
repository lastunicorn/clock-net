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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.Shapes.Basic;
using DustInTheWind.ClockNet.TimeProviders;

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


        #region Text

        private StringGroundShape defaultTextShape;
        private StringGroundShape DefaultTextShape
        {
            get
            {
                //if (defaultTextShape == null)
                {
                    foreach (IGroundShape shape in backgroundShapes)
                    {
                        if (shape is StringGroundShape)
                        {
                            defaultTextShape = (StringGroundShape)shape;
                            break;
                        }
                    }
                }

                return defaultTextShape;
            }
        }

        /// <summary>
        /// Gets or sets the text displayed by the first <see cref="StringGroundShape"/> object
        /// that can be found in the <see cref="BackgroundShapes"/> list.
        /// </summary>
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [Description("The text displayed by the first TextShape object that can be found in the BackgroundShapes list.")]
        public override string Text
        {
            get
            {
                StringGroundShape textShape = DefaultTextShape;

                return textShape != null
                    ? textShape.Text
                    : string.Empty;
            }
            set
            {
                StringGroundShape textShape = DefaultTextShape;

                if (textShape != null)
                    textShape.Text = value;
            }
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


        #region BackgroundShapeCollection class

        private class BackgroundShapeCollection : Collection<IGroundShape>
        {
            AnalogClock clock;

            /// <summary>
            /// Initializes a new instance of the <see cref="BackgroundShapeCollection"/> class.
            /// </summary>
            /// <param name="clock">The parent clock of the current instance.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public BackgroundShapeCollection(AnalogClock clock)
            {
                if (clock == null)
                    throw new ArgumentNullException("clock");

                this.clock = clock;
            }

            protected override void InsertItem(int index, IGroundShape item)
            {
                base.InsertItem(index, item);

                if (item != null)
                    item.Changed += new EventHandler(clock.shape_Changed);

                clock.Invalidate();
                clock.OnBackgroundShapeAdded(new ShapeAddedEventArgs(index, item));
            }

            protected override void RemoveItem(int index)
            {
                IGroundShape item = this[index];

                if (item != null)
                    item.Changed -= new EventHandler(clock.shape_Changed);

                base.RemoveItem(index);

                clock.Invalidate();
                clock.OnBackgroundShapeRemoved(new ShapeRemovedEventArgs(item));
            }

            protected override void SetItem(int index, IGroundShape item)
            {
                IGroundShape oldItem = this[index];

                if (oldItem != null)
                    oldItem.Changed -= new EventHandler(clock.shape_Changed);

                base.SetItem(index, item);

                clock.Invalidate();
                clock.OnBackgroundShapeRemoved(new ShapeRemovedEventArgs(oldItem));
                clock.OnBackgroundShapeAdded(new ShapeAddedEventArgs(index, item));
            }

            protected override void ClearItems()
            {
                foreach (IGroundShape item in Items)
                {
                    if (item != null)
                        item.Changed -= new EventHandler(clock.shape_Changed);
                }

                base.ClearItems();
            }
        }

        #endregion

        #region AngularShapeCollection class

        private class AngularShapeCollection : Collection<IAngularShape>
        {
            AnalogClock clock;

            /// <summary>
            /// Initializes a new instance of the <see cref="AngularShapeCollection"/> class.
            /// </summary>
            /// <param name="clock">The parent clock of the current instance.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public AngularShapeCollection(AnalogClock clock)
            {
                if (clock == null)
                    throw new ArgumentNullException("clock");

                this.clock = clock;
            }

            protected override void InsertItem(int index, IAngularShape item)
            {
                base.InsertItem(index, item);

                if (item != null)
                    item.Changed += new EventHandler(clock.shape_Changed);

                clock.Invalidate();
                clock.OnAngularShapeAdded(new ShapeAddedEventArgs(index, item));
            }

            protected override void RemoveItem(int index)
            {
                IAngularShape item = this[index];

                if (item != null)
                    item.Changed -= new EventHandler(clock.shape_Changed);

                base.RemoveItem(index);

                clock.Invalidate();
                clock.OnAngularShapeRemoved(new ShapeRemovedEventArgs(item));
            }

            protected override void SetItem(int index, IAngularShape item)
            {
                IAngularShape oldItem = this[index];

                if (oldItem != null)
                    oldItem.Changed -= new EventHandler(clock.shape_Changed);

                base.SetItem(index, item);

                clock.Invalidate();
                clock.OnBackgroundShapeRemoved(new ShapeRemovedEventArgs(oldItem));
                clock.OnBackgroundShapeAdded(new ShapeAddedEventArgs(index, item));
            }

            protected override void ClearItems()
            {
                foreach (IAngularShape item in Items)
                {
                    if (item != null)
                        item.Changed -= new EventHandler(clock.shape_Changed);
                }

                base.ClearItems();
            }
        }

        #endregion

        #region HandShapeCollection class

        private class HandShapeCollection : Collection<IHandShape>
        {
            AnalogClock clock;

            /// <summary>
            /// Initializes a new instance of the <see cref="HandShapeCollection"/> class.
            /// </summary>
            /// <param name="clock">The parent clock of the current instance.</param>
            /// <exception cref="ArgumentNullException"></exception>
            public HandShapeCollection(AnalogClock clock)
            {
                if (clock == null)
                    throw new ArgumentNullException("clock");

                this.clock = clock;
            }

            protected override void InsertItem(int index, IHandShape item)
            {
                base.InsertItem(index, item);

                if (item != null)
                    item.Changed += new EventHandler(clock.shape_Changed);

                clock.Invalidate();
                clock.OnHandShapeAdded(new ShapeAddedEventArgs(index, item));
            }

            protected override void RemoveItem(int index)
            {
                IHandShape item = this[index];

                if (item != null)
                    item.Changed -= new EventHandler(clock.shape_Changed);

                base.RemoveItem(index);

                clock.Invalidate();
                clock.OnHandShapeRemoved(new ShapeRemovedEventArgs(item));
            }

            protected override void SetItem(int index, IHandShape item)
            {
                IHandShape oldItem = this[index];

                if (oldItem != null)
                    oldItem.Changed -= new EventHandler(clock.shape_Changed);

                base.SetItem(index, item);

                clock.Invalidate();
                clock.OnBackgroundShapeRemoved(new ShapeRemovedEventArgs(oldItem));
                clock.OnBackgroundShapeAdded(new ShapeAddedEventArgs(index, item));
            }

            protected override void ClearItems()
            {
                foreach (IHandShape item in Items)
                {
                    if (item != null)
                        item.Changed -= new EventHandler(clock.shape_Changed);
                }

                base.ClearItems();
            }
        }

        #endregion


        #region BackgroundShapes

        /// <summary>
        /// The list of shapes that are drawn on the background of the clock.
        /// </summary>
        private BackgroundShapeCollection backgroundShapes;

        /// <summary>
        /// Gets the list of shapes that are drawn on the background of the clock.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that are drawn on the background of the clock.")]
        public Collection<IGroundShape> BackgroundShapes
        {
            get { return backgroundShapes; }
        }

        #endregion

        #region AngularShapes

        /// <summary>
        /// The list of shapes that are drawn repetitively on the edge of the clock.
        /// </summary>
        private AngularShapeCollection angularShapes;

        /// <summary>
        /// Gets the list of shapes that are drawn repetitively on the edge of the clock.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that are drawn repetitively on the edge of the clock.")]
        public Collection<IAngularShape> AngularShapes
        {
            get { return angularShapes; }
        }

        #endregion

        #region HandShapes

        /// <summary>
        /// The list of shapes that display the time.
        /// </summary>
        private HandShapeCollection handShapes;

        /// <summary>
        /// Gets the list of shapes that display the time.
        /// </summary>
        [Category("Shapes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ShapeCollectionEditor), typeof(UITypeEditor))]
        [Description("The list of shapes that display the time.")]
        public Collection<IHandShape> HandShapes
        {
            get { return handShapes; }
        }

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
            get { return keepProportions; }
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
        /// <param name="shapeSet">An <see cref="ShapeSet"/> object containing the shapes that creats the interface.</param>
        /// <param name="timeProvider">An instance of the <see cref="ITimeProvider"/> that provides the time to be displayed in the control.</param>
        public AnalogClock(ShapeSet shapeSet, ITimeProvider timeProvider)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);

            backgroundShapes = new BackgroundShapeCollection(this);
            angularShapes = new AngularShapeCollection(this);
            handShapes = new HandShapeCollection(this);

            if (shapeSet != null)
            {
                if (shapeSet.BackgroundShapes != null)
                {
                    foreach (IGroundShape shape in shapeSet.BackgroundShapes)
                    {
                        backgroundShapes.Add(shape);
                    }
                }

                if (shapeSet.AngularShapes != null)
                {
                    foreach (IAngularShape shape in shapeSet.AngularShapes)
                    {
                        angularShapes.Add(shape);
                    }
                }

                if (shapeSet.HandShapes != null)
                {
                    foreach (IHandShape shape in shapeSet.HandShapes)
                    {
                        handShapes.Add(shape);
                    }
                }
            }

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


        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x20;
        //        return cp;
        //    }
        //}


        /// <summary>
        /// Call-back function called when one of the shapes is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shape_Changed(object sender, EventArgs e)
        {
            Debug.WriteLine(sender.GetType().ToString());
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="TimeProvider"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Matrix originalMatrix = e.Graphics.Transform;

            g.TranslateTransform(centerX, centerY);
            g.ScaleTransform(scaleX, scaleY);
            Matrix centerMatrix = e.Graphics.Transform;

            // Draw the background shapes.
            foreach (IGroundShape shape in backgroundShapes)
            {
                if (shape != null)
                {
                    g.Transform = centerMatrix;

                    shape.Draw(g);
                }
            }

            // Draw the angular shapes.

            float angleIncrement = CalculateAngleIncrement();

            if (angleIncrement > 0)
            {
                for (float i = 0; i <= 360; i += angleIncrement)
                {
                    foreach (IAngularShape shape in angularShapes)
                    {
                        g.Transform = centerMatrix;
                        g.RotateTransform(i);

                        g.TranslateTransform(0f, -radius);

                        if ((shape.Index == 0 || shape.Repeat) && i % shape.Angle == 0)
                        {
                            shape.Draw(g);
                        }
                    }
                }
            }

            // Draw the hand shapes.
            foreach (IHandShape shape in handShapes)
            {
                if (shape != null)
                {
                    g.Transform = centerMatrix;

                    shape.Time = time;
                    shape.Draw(g);
                }
            }

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

        private float CalculateAngleIncrement()
        {
            if (angularShapes.Count == 1)
            {
                angularShapes[0].Reset();
                return angularShapes[0].Angle;
            }
            else if (angularShapes.Count > 1)
            {
                angularShapes[0].Reset();
                angularShapes[1].Reset();

                float angleIncrement = GreatestCommonFactor(angularShapes[0].Angle, angularShapes[1].Angle);

                for (int i = 2; i < angularShapes.Count; i++)
                {
                    angularShapes[i].Reset();

                    angleIncrement = GreatestCommonFactor(angleIncrement, angularShapes[i].Angle);
                }

                return angleIncrement;
            }
            else
            {
                return 0f;
            }
        }

        static float GreatestCommonFactor(float num1, float num2)
        {
            //while (num2 != 0)
            while (num2 > double.Epsilon)
            {
                float temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }
            return num1;
        }

        #endregion

        /// <summary>
        /// Sets a new set of shapes to be used by the clock.
        /// </summary>
        /// <param name="shapeSet">An instance of <see cref="ShapeSet"/> class containing the <see cref="IShape"/> instances.</param>
        public void SetShapes(ShapeSet shapeSet)
        {
            if (shapeSet != null)
            {
                backgroundShapes.Clear();
                if (shapeSet.BackgroundShapes != null)
                {
                    foreach (IGroundShape shape in shapeSet.BackgroundShapes)
                    {
                        backgroundShapes.Add(shape);
                    }
                }

                angularShapes.Clear();
                if (shapeSet.AngularShapes != null)
                {
                    foreach (IAngularShape shape in shapeSet.AngularShapes)
                    {
                        angularShapes.Add(shape);
                    }
                }

                handShapes.Clear();
                if (shapeSet.HandShapes != null)
                {
                    foreach (IHandShape shape in shapeSet.HandShapes)
                    {
                        handShapes.Add(shape);
                    }
                }
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (IGroundShape shape in backgroundShapes)
                {
                    if (shape != null)
                        shape.Dispose();
                }

                foreach (IAngularShape shape in angularShapes)
                {
                    if (shape != null)
                        shape.Dispose();
                }

                foreach (IHandShape shape in handShapes)
                {
                    if (shape != null)
                        shape.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            using (Matrix m = new Matrix())
            {
                m.Translate(-centerX, -centerY);
                m.Scale(1 / scaleX, 1 / scaleY, MatrixOrder.Append);

                PointF[] points = new PointF[] { e.Location };
                m.TransformPoints(points);
                PointF clickLocation = points[0];

                //Console.WriteLine("click: {0}; {1}", points[0].X, points[0].Y);

                for (int i = handShapes.Count - 1; i >= 0; i--)
                {
                    if (handShapes[i].HitTest(points[0]))
                    {
                        Console.WriteLine(handShapes[i].Name);
                        break;
                    }
                }

                base.OnMouseClick(e);
            }
        }
    }
}
