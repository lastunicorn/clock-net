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
using DustInTheWind.Clock.Shapes.Default;

namespace DustInTheWind.Clock
{
    /// <summary>
    /// An Windows Forms control that displays an old style analog clock.
    /// </summary>
    /// <remarks>
    /// <para>If the compilation symbol "PERFORMANCE_INFO" is used at compile time, additional information about the
    /// time consumed with the OnPaint method are displayed in the upper left corner of the control.</para>
    /// <para>If the "PERFORMANCE_INFO" symbol is not used, the code necessary to colect performance information will
    /// not be compiled at all, so it will not influence the performance.</para>
    /// </remarks>
    [Designer(typeof(AnalogClockDesigner))]
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
        /// An instance of <see cref="IHandShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        private IHandShape hourHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IHandShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        [Category("Shapes")]
        [DefaultValue(typeof(HourHandShape), DustInTheWind.Clock.Shapes.Default.HourHandShape.NAME)]
        [TypeConverter(typeof(ShapeConverter))]
        [Description("An instance of IHandShape responsable to paint the hour hand in the position specified by the clock.")]
        public IHandShape HourHandShape
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
        /// An instance of <see cref="IHandShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        private IHandShape minuteHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IHandShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        [Category("Shapes")]
        [DefaultValue(null)]
        [Description("An instance of IHandShape responsable to paint the minute hand in the position specified by the clock.")]
        public IHandShape MinuteHandShape
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
        /// An instance of <see cref="IHandShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        private IHandShape sweepHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IHandShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        [Category("Shapes")]
        [DefaultValue(null)]
        [Description("An instance of IHandShape responsable to paint the sweep hand in the position specified by the clock.")]
        public IHandShape SweepHandShape
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
        /// An instance of <see cref="IShape"/> responsable to paint the pin from the center of the clock.
        /// </summary>
        private IShape pinShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the pin from the center of the clock.
        /// </summary>
        [Category("Shapes")]
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
        /// An instance of <see cref="IShape"/> responsable to paint the tick lines that marks the seconds.
        /// </summary>
        private IShape ticks1Shape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the tick lines that marks the seconds.
        /// </summary>
        [Category("Shapes")]
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
        /// An instance of <see cref="IShape"/> responsable to paint the tick lines that marks every 5 seconds.
        /// </summary>
        private IShape ticks5Shape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the tick lines that marks every 5 seconds.
        /// </summary>
        [Category("Shapes")]
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
        /// An instance of <see cref="IArrayShape"/> responsable to paint the numbers that marks the hours.
        /// </summary>
        private IArrayShape numbersShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IArrayShape"/> responsable to paint the numbers that marks the hours.
        /// </summary>
        [Category("Shapes")]
        [DefaultValue(null)]
        [Description("An instance of IArrayShape responsable to paint the numbers that marks the hours.")]
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

        #region Text

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the text from the background of the clock.
        /// </summary>
        private IShape textShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the text from the background of the clock.
        /// </summary>
        [Category("Shapes")]
        [DefaultValue(null)]
        [Description("An instance of IShape responsable to paint the text from the background of the clock.")]
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

            InitializeComponent();

            if (shapeSet != null)
            {
                if (shapeSet.DialShape != null)
                {
                    dialShape = shapeSet.DialShape;
                    dialShape.Changed += new EventHandler(dialShape_Changed);
                }

                if (shapeSet.HourHandShape != null)
                {
                    hourHandShape = shapeSet.HourHandShape;
                    hourHandShape.Changed += new EventHandler(hourHandShape_Changed);
                }

                if (shapeSet.MinuteHandShape != null)
                {
                    minuteHandShape = shapeSet.MinuteHandShape;
                    minuteHandShape.Changed += new EventHandler(minuteHandShape_Changed);
                }

                if (shapeSet.SweepHandShape != null)
                {
                    sweepHandShape = shapeSet.SweepHandShape;
                    sweepHandShape.Changed += new EventHandler(sweepHandShape_Changed);
                }

                if (shapeSet.PinShape != null)
                {
                    pinShape = shapeSet.PinShape;
                    pinShape.Changed += new EventHandler(pinShape_Changed);
                }

                if (shapeSet.Ticks1Shape != null)
                {
                    ticks1Shape = shapeSet.Ticks1Shape;
                    ticks1Shape.Changed += new EventHandler(ticks1Shape_Changed);
                }

                if (shapeSet.Ticks5Shape != null)
                {
                    ticks5Shape = shapeSet.Ticks5Shape;
                    ticks5Shape.Changed += new EventHandler(ticks5Shape_Changed);
                }

                if (shapeSet.NumbersShape != null)
                {
                    numbersShape = shapeSet.NumbersShape;
                    numbersShape.Changed += new EventHandler(numbersShape_Changed);
                }

                if (shapeSet.TextShape != null)
                {
                    textShape = shapeSet.TextShape;
                    textShape.Changed += new EventHandler(textShape_Changed);
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

        #region Performance Info

#if PERFORMANCE_INFO

        // >> Needed to display performance info.

        /// <summary>
        /// Counts the times the control has been repainted.
        /// </summary>
        private long paintCount = 0;

        /// <summary>
        /// Keeps the total time (in ticks) the control consumed executing the <see cref="OnPaint"/> method.
        /// </summary>
        private long paintTotalTicks = 0;

#endif

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {

#if PERFORMANCE_INFO

            // >> Needed to display performance info.

            // Create and start a new Stopwatch.
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
                    if (ticks5Shape != null)
                    {
                        ticks5Shape.Draw(g);
                    }

                    // Draw the numbers.
                    if (numbersShape != null)
                    {
                        numbersShape.CurrentIndex = i / 5 - 1;
                        numbersShape.Draw(g);
                    }
                }
                else
                {
                    // Draw the ticks.
                    if (ticks1Shape != null)
                    {
                        ticks1Shape.Draw(g);
                    }
                }
            }

            g.Transform = centerMatrix;


            //// Create the brush if it does not exist.
            //if (textBrush == null)
            //    textBrush = new SolidBrush(ForeColor);

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
            if (hourHandShape != null)
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
            if (minuteHandShape != null)
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
            if (sweepHandShape != null)
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

            if (pinShape != null)
                pinShape.Draw(g);

#if PERFORMANCE_INFO

            // >> Needed to display performance info.

            stopwatch.Stop();

            paintCount++;
            paintTotalTicks += stopwatch.ElapsedTicks;

            long averageTicks = paintTotalTicks / paintCount;

            string text = string.Format("average: {1} ms\ninstant: {0} ms\ncount: {2}",
                TimeSpan.FromTicks(stopwatch.ElapsedTicks).TotalMilliseconds,
                TimeSpan.FromTicks(averageTicks).TotalMilliseconds,
                paintCount);

            g.Transform = originalMatrix;
            using (Font performanceTestFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
            {
                g.DrawString(text, performanceTestFont, Brushes.Black, 0, 0);
            }

#endif

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
                DialShape = shapeSet.DialShape;
                HourHandShape = shapeSet.HourHandShape;
                MinuteHandShape = shapeSet.MinuteHandShape;
                SweepHandShape = shapeSet.SweepHandShape;
                PinShape = shapeSet.PinShape;
                Ticks1Shape = shapeSet.Ticks1Shape;
                Ticks5Shape = shapeSet.Ticks5Shape;
                NumbersShape = shapeSet.NumbersShape;
                TextShape = shapeSet.TextShape;
            }
        }
    }
}
