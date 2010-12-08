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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.TimeProviders;

namespace DustInTheWind.Clock
{
    /// <summary>
    /// An Windows Forms control that displays a time as an old style analog clock.
    /// </summary>
    public partial class AnalogClock : Control
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
            if (TimeProviderChanged != null)
            {
                TimeProviderChanged(this, e);
            }
        }

        #endregion

        #region Event HourHandShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="HourHandShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the HourHandShape property is changed.")]
        public event EventHandler HourHandShapeChanged;

        /// <summary>
        /// Raises the <see cref="HourHandShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnHourHandShapeChanged(EventArgs e)
        {
            if (HourHandShapeChanged != null)
            {
                HourHandShapeChanged(this, e);
            }
        }

        #endregion

        #region Event MinuteHandShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="MinuteHandShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the MinuteHandShape property is changed.")]
        public event EventHandler MinuteHandShapeChanged;

        /// <summary>
        /// Raises the <see cref="MinuteHandShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnMinuteHandShapeChanged(EventArgs e)
        {
            if (MinuteHandShapeChanged != null)
            {
                MinuteHandShapeChanged(this, e);
            }
        }

        #endregion

        #region Event SweepHandShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="SweepHandShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the SweepHandShape property is changed.")]
        public event EventHandler SweepHandShapeChanged;

        /// <summary>
        /// Raises the <see cref="SweepHandShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnSweepHandShapeChanged(EventArgs e)
        {
            if (SweepHandShapeChanged != null)
            {
                SweepHandShapeChanged(this, e);
            }
        }

        #endregion

        #region Event PinShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="PinShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the PinShape property is changed.")]
        public event EventHandler PinShapeChanged;

        /// <summary>
        /// Raises the <see cref="PinShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnPinShapeChanged(EventArgs e)
        {
            if (PinShapeChanged != null)
            {
                PinShapeChanged(this, e);
            }
        }

        #endregion

        #region Event Ticks1ShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="Ticks1Shape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the Ticks1Shape property is changed.")]
        public event EventHandler Ticks1ShapeChanged;

        /// <summary>
        /// Raises the <see cref="Ticks1ShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnTicks1ShapeChanged(EventArgs e)
        {
            if (Ticks1ShapeChanged != null)
            {
                Ticks1ShapeChanged(this, e);
            }
        }

        #endregion

        #region Event Ticks5ShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="Ticks5Shape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the Ticks5Shape property is changed.")]
        public event EventHandler Ticks5ShapeChanged;

        /// <summary>
        /// Raises the <see cref="Ticks5ShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnTicks5ShapeChanged(EventArgs e)
        {
            if (Ticks5ShapeChanged != null)
            {
                Ticks5ShapeChanged(this, e);
            }
        }

        #endregion

        #region Event DialShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="DialShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the DialShape property is changed.")]
        public event EventHandler DialShapeChanged;

        /// <summary>
        /// Raises the <see cref="NumbersShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnDialShapeChanged(EventArgs e)
        {
            if (DialShapeChanged != null)
            {
                DialShapeChanged(this, e);
            }
        }

        #endregion

        #region Event NumbersShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="NumbersShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the NumbersShape property is changed.")]
        public event EventHandler NumbersShapeChanged;

        /// <summary>
        /// Raises the <see cref="NumbersShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnNumbersShapeChanged(EventArgs e)
        {
            if (NumbersShapeChanged != null)
            {
                NumbersShapeChanged(this, e);
            }
        }

        #endregion

        #region Event TextShapeChanged

        /// <summary>
        /// Event raised when the value of the <see cref="TextShape"/> property is changed.
        /// </summary>
        [Category("Property Changed")]
        [Description("Event raised when the value of the TextShape property is changed.")]
        public event EventHandler TextShapeChanged;

        /// <summary>
        /// Raises the <see cref="TextShapeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
        protected virtual void OnTextShapeChanged(EventArgs e)
        {
            if (TextShapeChanged != null)
            {
                TextShapeChanged(this, e);
            }
        }

        #endregion



        #region Time

        /// <summary>
        /// The time displayed by the control.
        /// </summary>
        private TimeSpan time;

        /// <summary>
        /// Gets or sets the time displayed by the control.
        /// </summary>
        [Category("Value")]
        [DefaultValue(typeof(TimeSpan), "0")]
        [Description("The time displayed by the control.")]
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
        /// Displays the system's UTC time.
        /// </summary>
        private void DisplayUtcTime()
        {
            time = DateTime.UtcNow.TimeOfDay;
            Invalidate();
        }

        /// <summary>
        /// Displays the system's UTC time added with the specified offset value.
        /// </summary>
        private void DisplayUtcTime(TimeSpan offset)
        {
            time = DateTime.UtcNow.TimeOfDay.Add(offset);
            Invalidate();
        }

        /// <summary>
        /// Displays the system's local time.
        /// </summary>
        private void DisplayLocalTime()
        {
            time = DateTime.Now.TimeOfDay;
            Invalidate();
        }

        /// <summary>
        /// Retrieves a new <see cref="TimeSpan"/> value from the time provider and displays it.
        /// </summary>
        private void DisplayProvidedTime()
        {
            time = timeProvider.GetTime();
            Invalidate();
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
                    if (timeProvider != null)
                    {
                        time = timeProvider.GetTime();
                        Invalidate();
                    }
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
            if (timeProvider != null)
            {
                time = timeProvider.GetTime();
                Invalidate();
            }
        }

        #endregion

        #region Time Provider

        /// <summary>
        /// An instance of the <see cref="ITimeProvider"/> that provides the time to be displayed by the timer every time the timer asks for it.
        /// </summary>
        private ITimeProvider timeProvider;

        /// <summary>
        /// An instance of the <see cref="ITimeProvider"/> that provides the time to be displayed by the timer every time the timer asks for it.
        /// </summary>
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



        #region Hour Hand

        /// <summary>
        /// A value that specifies if the hour hand should be displayed.
        /// </summary>
        private bool hourHandVisible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the hour hand should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the hour hand should be displayed.")]
        public bool HourHandVisible
        {
            get { return hourHandVisible; }
            set
            {
                hourHandVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// A value that specifies if the hour hand should point exactly to the hour marks and never between them.
        /// </summary>
        private bool integralHour = false;

        /// <summary>
        /// Gets or sets a value that specifies if the hour hand should point exactly to the hour marks and never between them.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Specifies if the hour hand should point exactly to the hour marks and never between them.")]
        public bool IntegralHour
        {
            get { return integralHour; }
            set
            {
                integralHour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        private IShape hourHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        [Category("Shapes")]
        //[Editor(typeof(ShapeSelectorEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the hour hand in the position specified by the clock.")]
        public IShape HourHandShape
        {
            get { return hourHandShape; }
            set
            {
                if (hourHandShape != null)
                    hourHandShape.Changed -= new EventHandler(hourHandShape_Changed);

                hourHandShape = value;

                if (hourHandShape != null)
                    hourHandShape.Changed += new EventHandler(hourHandShape_Changed);

                Invalidate();

                OnHourHandShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Minute Hand

        /// <summary>
        /// A value that specifies if the minute hand should be displayed.
        /// </summary>
        private bool minuteHandVisible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the minute hand should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the minute hand should be displayed.")]
        public bool MinuteHandVisible
        {
            get { return minuteHandVisible; }
            set
            {
                minuteHandVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// A value that specifies if the minute hand should point exactly to the minute marks and never between them.
        /// </summary>
        private bool integralMinute = false;

        /// <summary>
        /// Gets or sets a value that specifies if the minute hand should point exactly to the minute marks and never between them.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Specifies if the hour hand should point exactly to the hour marks and never between them.")]
        public bool IntegralMinute
        {
            get { return integralMinute; }
            set
            {
                integralMinute = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        private IShape minuteHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the minute hand in the position specified by the clock.")]
        public IShape MinuteHandShape
        {
            get { return minuteHandShape; }
            set
            {
                if (minuteHandShape != null)
                    minuteHandShape.Changed -= new EventHandler(minuteHandShape_Changed);

                minuteHandShape = value;

                if (minuteHandShape != null)
                    minuteHandShape.Changed += new EventHandler(minuteHandShape_Changed);

                Invalidate();

                OnMinuteHandShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Sweep Hand

        /// <summary>
        /// A value that specifies if the sweep hand should be displayed.
        /// </summary>
        private bool sweepHandVisible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the sweep hand should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("A value that specifies if the sweep hand should be displayed.")]
        public bool SweepHandVisible
        {
            get { return sweepHandVisible; }
            set
            {
                sweepHandVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// A value that specifies if the sweep hand should point exactly to the second's marks and never between them.
        /// </summary>
        private bool integralSecond = true;

        /// <summary>
        /// Gets or sets a value that specifies if the sweep hand should point exactly to the second's marks and never between them.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the sweep hand should point exactly to the second's marks and never between them.")]
        public bool IntegralSecond
        {
            get { return integralSecond; }
            set
            {
                integralSecond = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        private IShape sweepHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the sweep hand in the position specified by the clock.")]
        public IShape SweepHandShape
        {
            get { return sweepHandShape; }
            set
            {
                if (sweepHandShape != null)
                    sweepHandShape.Changed -= new EventHandler(sweepHandShape_Changed);

                sweepHandShape = value;

                if (sweepHandShape != null)
                    sweepHandShape.Changed += new EventHandler(sweepHandShape_Changed);

                Invalidate();

                OnSweepHandShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Pin

        /// <summary>
        /// A value that specifies if the pin should be displayed.
        /// </summary>
        private bool pinVisible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the pin should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the pin should be displayed.")]
        public bool PinVisible
        {
            get { return pinVisible; }
            set
            {
                pinVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the pin from the center of the clock.
        /// </summary>
        private IShape pinShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the pin from the center of the clock.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the pin from the center of the clock.")]
        public IShape PinShape
        {
            get { return pinShape; }
            set
            {
                if (pinShape != null)
                    pinShape.Changed -= new EventHandler(pinShape_Changed);

                pinShape = value;

                if (pinShape != null)
                    pinShape.Changed += new EventHandler(pinShape_Changed);

                Invalidate();

                OnPinShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Ticks1

        /// <summary>
        /// A value that specifies if the tick lines that marks the seconds should be displayed.
        /// </summary>
        private bool ticks1Visible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the tick lines that marks the seconds should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the tick lines that marks the seconds should be displayed.")]
        public bool Ticks1Visible
        {
            get { return ticks1Visible; }
            set
            {
                ticks1Visible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the tick lines that marks the seconds.
        /// </summary>
        private IShape ticks1Shape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the tick lines that marks the seconds.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the tick lines that marks the seconds.")]
        public IShape Ticks1Shape
        {
            get { return ticks1Shape; }
            set
            {
                if (ticks1Shape != null)
                    ticks1Shape.Changed -= new EventHandler(ticks1Shape_Changed);

                ticks1Shape = value;

                if (ticks1Shape != null)
                    ticks1Shape.Changed += new EventHandler(ticks1Shape_Changed);

                Invalidate();

                OnTicks1ShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Ticks5

        /// <summary>
        /// A value that specifies if the tick lines that marks every 5 seconds should be displayed.
        /// </summary>
        private bool ticks5Visible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the tick lines that marks every 5 seconds should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the tick lines that marks every 5 seconds should be displayed.")]
        public bool Ticks5Visible
        {
            get { return ticks5Visible; }
            set
            {
                ticks5Visible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the tick lines that marks every 5 seconds.
        /// </summary>
        private IShape ticks5Shape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the tick lines that marks every 5 seconds.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the tick lines that marks every 5 seconds.")]
        public IShape Ticks5Shape
        {
            get { return ticks5Shape; }
            set
            {
                if (ticks5Shape != null)
                    ticks5Shape.Changed -= new EventHandler(ticks5Shape_Changed);

                ticks5Shape = value;

                if (ticks5Shape != null)
                    ticks5Shape.Changed += new EventHandler(ticks5Shape_Changed);

                Invalidate();

                OnTicks5ShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Numbers

        /// <summary>
        /// A value that specifies if the number should be displayed.
        /// </summary>
        private bool numbersVisible = true;

        /// <summary>
        /// Gets or sets a value that specifies if the number should be displayed.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the number should be displayed.")]
        public bool NumbersVisible
        {
            get { return numbersVisible; }
            set
            {
                numbersVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// An instance of <see cref="INumbersShape"/> responsable to paint the numbers that marks the hours.
        /// </summary>
        private IArrayShape numbersShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="INumbersShape"/> responsable to paint the numbers that marks the hours.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of INumbersShape responsable to paint the numbers that marks the hours.")]
        public IArrayShape NumbersShape
        {
            get { return numbersShape; }
            set
            {
                if (numbersShape != null)
                    numbersShape.Changed -= new EventHandler(numbersShape_Changed);

                numbersShape = value;

                if (numbersShape != null)
                    numbersShape.Changed += new EventHandler(numbersShape_Changed);

                Invalidate();

                OnNumbersShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Dial

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the background of the dial.
        /// </summary>
        private IShape dialShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the background of the dial.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the background of the dial.")]
        public IShape DialShape
        {
            get { return dialShape; }
            set
            {
                if (dialShape != null)
                    dialShape.Changed -= new EventHandler(dialShape_Changed);

                dialShape = value;

                if (dialShape != null)
                    dialShape.Changed += new EventHandler(dialShape_Changed);

                Invalidate();

                OnDialShapeChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Miscellaneous

        private bool keepProportions = true;

        [Category("Appearance")]
        [DefaultValue(true)]
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

        #region Text

        /// <summary>
        /// Gets or sets the text displayed on the dial of the clock.
        /// </summary>
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color used to draw the text from the dial of the clock.
        /// </summary>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                InvalidateTextBrush();
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the text displayed on the background of the clock.
        /// </summary>
        private IShape textShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the text displayed on the background of the clock.
        /// </summary>
        [Category("Shapes")]
        [TypeConverter(typeof(ShapeConverter))]
        [DefaultValue(null)]
        [Description("An instance of INumbersShape responsable to paint the text displayed on the background of the clock.")]
        public IShape TextShape
        {
            get { return textShape; }
            set
            {
                if (textShape != null)
                    textShape.Changed -= new EventHandler(textShape_Changed);

                textShape = value;

                if (textShape != null)
                    textShape.Changed += new EventHandler(textShape_Changed);

                Invalidate();

                OnTextShapeChanged(EventArgs.Empty);
            }
        }

        #endregion


        #region Brushes and Pens

        /// <summary>
        /// The brush used to draw the text in the middle of the clock.
        /// </summary>
        private Brush textBrush;

        /// <summary>
        /// Disposes the brush used to draw the text in the middle of the clock.
        /// </summary>
        private void InvalidateTextBrush()
        {
            if (textBrush != null)
            {
                textBrush.Dispose();
                textBrush = null;
            }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalogClock"/> class with
        /// default aspect of the interface.
        /// </summary>
        public AnalogClock()
            : this(ShapeSet.Default, new LocalTimeProvider())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalogClock"/> class with
        /// a set of shapes and a time provider.
        /// </summary>
        public AnalogClock(ShapeSet shapeSet, ITimeProvider timeProvider)
            : this(shapeSet.DialShape, shapeSet.HourHandShape, shapeSet.MinuteHandShape, shapeSet.SweepHandShape, shapeSet.PinShape, shapeSet.Ticks1Shape, shapeSet.Ticks5Shape, shapeSet.NumbersShape, shapeSet.TextShape, timeProvider)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalogClock"/> class with
        /// the necessary shapes to create the interface.
        /// </summary>
        public AnalogClock(IShape dialShape, IShape hourHandShape, IShape minuteHandShape, IShape sweepHandShape, IShape pinShape,
            IShape ticks1Shape, IShape ticks5Shape, IArrayShape numbersShape, IShape textShape, ITimeProvider timeProvider)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);

            InitializeComponent();

            if (dialShape != null)
            {
                this.dialShape = dialShape;
                this.dialShape.Changed += new EventHandler(dialShape_Changed);
            }

            if (hourHandShape != null)
            {
                this.hourHandShape = hourHandShape;
                this.hourHandShape.Changed += new EventHandler(hourHandShape_Changed);
            }

            if (minuteHandShape != null)
            {
                this.minuteHandShape = minuteHandShape;
                this.minuteHandShape.Changed += new EventHandler(minuteHandShape_Changed);
            }

            if (sweepHandShape != null)
            {
                this.sweepHandShape = sweepHandShape;
                this.sweepHandShape.Changed += new EventHandler(sweepHandShape_Changed);
            }

            if (pinShape != null)
            {
                this.pinShape = pinShape;
                this.pinShape.Changed += new EventHandler(pinShape_Changed);
            }

            if (ticks1Shape != null)
            {
                this.ticks1Shape = ticks1Shape;
                this.ticks1Shape.Changed += new EventHandler(ticks1Shape_Changed);
            }

            if (ticks5Shape != null)
            {
                this.ticks5Shape = ticks5Shape;
                this.ticks5Shape.Changed += new EventHandler(ticks5Shape_Changed);
            }

            if (numbersShape != null)
            {
                this.numbersShape = numbersShape;
                this.numbersShape.Changed += new EventHandler(numbersShape_Changed);
            }

            if (textShape != null)
            {
                this.textShape = textShape;
                this.textShape.Changed += new EventHandler(textShape_Changed);
            }

            if (timeProvider != null)
            {
                this.timeProvider = timeProvider;
                this.timeProvider.Changed += new EventHandler(timeProvider_Changed);
            }

            //this.hourHandShape = hourHandShape == null ? new HourHandShape() : hourHandShape;
            //this.hourHandShape.Changed += new EventHandler(hourHandShape_Changed);

            //this.minuteHandShape = minuteHandShape == null ? new MinuteHandShape() : minuteHandShape;
            //this.minuteHandShape.Changed += new EventHandler(minuteHandShape_Changed);

            //this.sweepHandShape = sweepHandShape == null ? new SweepHandShape() : sweepHandShape;
            //this.sweepHandShape.Changed += new EventHandler(sweepHandShape_Changed);

            //this.pinShape = pinShape == null ? new PinShape() : pinShape;
            //this.pinShape.Changed += new EventHandler(pinShape_Changed);

            //this.ticks1Shape = ticks1Shape == null ? new Ticks1Shape() : ticks1Shape;
            //this.ticks1Shape.Changed += new EventHandler(ticks1Shape_Changed);

            //this.ticks5Shape = ticks5Shape == null ? new Ticks5Shape() : ticks5Shape;
            //this.ticks5Shape.Changed += new EventHandler(ticks5Shape_Changed);

            //this.numbersShape = numbersShape == null ? new NumbersShape(Font) : numbersShape;
            //this.numbersShape.Changed += new EventHandler(numbersShape_Changed);

            //this.timeProvider = timeProvider == null ? new LocalTimeProvider() : timeProvider;
            //this.timeProvider.Changed += new EventHandler(timeProvider_Changed);

            //this.dialShape = new DialShape(Color.Empty, true);
            //this.dialShape.Changed += new EventHandler(dialShape_Changed);

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

        #region Shapes call-backs

        /// <summary>
        /// Call-back function called when the <see cref="HourHandShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hourHandShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="MinuteHandShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minuteHandShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="SweepHandShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sweepHandShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="PinShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pinShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="Ticks1Shape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ticks1Shape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="Ticks5Shape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ticks5Shape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="NumbersShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numbersShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="DialShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dialShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Call-back function called when the <see cref="TextShape"/> is changed. And the clock needs repainting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textShape_Changed(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion

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


                //diameter = realDiameter;
                radius = diameter / 2;
                centerX = Padding.Left + drawableWidth / 2;
                centerY = Padding.Top + drawableHeight / 2;
            }
        }

        #endregion


        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);

            CalculateDimmensions();
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            CalculateDimmensions();
            Invalidate();
        }

        #region Performance

#if PERFORMANCE_TEST

        private long paintCount = 0;
        private long paintTotalTicks = 0;

#endif

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {

#if PERFORMANCE_TEST
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
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

            if (dialShape != null)
            {
                dialShape.Draw(g);
            }

            for (int i = 1; i <= 60; i++)
            {
                g.Transform = centerMatrix;
                g.RotateTransform(i * 6); // 6 degrees between every tick.

                g.TranslateTransform(0f, -radius);

                if (i % 5 == 0)
                {
                    // Draw the ticks.
                    if (ticks5Visible && ticks5Shape != null)
                    {
                        ticks5Shape.Draw(g);
                    }

                    // Draw the numbers.
                    if (numbersVisible && numbersShape != null)
                    {
                        numbersShape.CurrentIndex = i / 5 - 1;
                        numbersShape.Draw(g);
                    }
                }
                else
                {
                    // Draw the ticks.
                    if (ticks1Visible && ticks1Shape != null)
                    {
                        ticks1Shape.Draw(g);
                    }
                }
            }

            g.Transform = centerMatrix;


            // Create the brush if it does not exist.
            if (textBrush == null)
                textBrush = new SolidBrush(ForeColor);

            // Draw the text.
            if (textShape != null)
            {
                textShape.Draw(g);
            }
            //using (StringFormat sf = new StringFormat())
            //{
            //    sf.Alignment = StringAlignment.Center;
            //    sf.LineAlignment = StringAlignment.Center;
            //    sf.Trimming = StringTrimming.None;

            //    SizeF textSize = g.MeasureString(Text, Font, (int)radius);
            //    PointF textLocation = new PointF(-textSize.Width / 2F, radius / 5F);

            //    g.DrawString(Text, Font, textBrush, new RectangleF(textLocation, textSize), sf);
            //}

            // Draw the hour hand.
            if (hourHandVisible && hourHandShape != null)
            {
                float hourDegrees;

                if (integralHour)
                    hourDegrees = (float)((time.Hours % 12) * 30);
                else
                    hourDegrees = (float)((time.Hours % 12 + time.Minutes / 60F) * 30);

                g.Transform = centerMatrix;
                g.RotateTransform(hourDegrees);

                // Draw the shape.
                hourHandShape.Draw(g);
            }

            // Draw the minute hand.
            if (minuteHandVisible && minuteHandShape != null)
            {
                float minuteDegrees;

                if (integralMinute)
                    minuteDegrees = (float)(time.Minutes * 6);
                else
                    minuteDegrees = (float)((time.Minutes + time.Seconds / 60F) * 6);

                g.Transform = centerMatrix;
                g.RotateTransform(minuteDegrees);

                // Draw the shape.
                minuteHandShape.Draw(g);
            }

            // Draw the sweep hand.
            if (sweepHandVisible && sweepHandShape != null)
            {
                float sweepDegrees;

                if (integralSecond)
                    sweepDegrees = (float)(time.Seconds * 6);
                else
                    sweepDegrees = (float)((time.Seconds + time.Milliseconds / 1000F) * 6);

                g.Transform = centerMatrix;
                g.RotateTransform(sweepDegrees);

                // Draw the shape.
                sweepHandShape.Draw(g);
            }

            g.Transform = centerMatrix;

            if (pinVisible)
                pinShape.Draw(g);

#if PERFORMANCE_TEST

            stopwatch.Stop();

            paintCount++;
            paintTotalTicks += stopwatch.ElapsedTicks;

            long averageTicks = paintTotalTicks / paintCount;

            g.Transform = originalMatrix;
            using (Font performanceTestFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
            {
                g.DrawString(TimeSpan.FromTicks(averageTicks).TotalMilliseconds.ToString() + " ms", performanceTestFont, Brushes.Black, 0, 0);
            }

            // 0.36 ms - intel core i5 2.4GHz - win7

#endif
        }

        #endregion

        public void SetShapes(ShapeSet shapeSet)
        {
            DialShape = shapeSet.DialShape;
            HourHandShape = shapeSet.HourHandShape;
            MinuteHandShape = shapeSet.MinuteHandShape;
            SweepHandShape = shapeSet.SweepHandShape;
            PinShape = shapeSet.PinShape;
            Ticks1Shape = shapeSet.Ticks1Shape;
            Ticks5Shape = shapeSet.Ticks5Shape;
            NumbersShape = shapeSet.NumbersShape;
        }
    }
}
