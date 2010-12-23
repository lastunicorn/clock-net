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

using System.Drawing;
using DustInTheWind.Clock.Properties;
using DustInTheWind.Clock.Shapes.Basic;
using DustInTheWind.Clock.Shapes.Default;
using DustInTheWind.Clock.Shapes.Fancy;

namespace DustInTheWind.Clock.Shapes
{
    public class ShapeSet
    {
        public static ShapeSet Empty
        {
            get { return new ShapeSet(); }
        }

        public static ShapeSet Default
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    new DustInTheWind.Clock.Shapes.Default.TextShape()
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 5f, 0.3f, 7f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 5f, 1f, 7f);
                ticks5Shape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    new TextAngularShape()
                };

                HourHandShape hourHandShape = new HourHandShape();
                MinuteHandShape minuteHandShape = new MinuteHandShape();
                //SweepHandShape sweepHandShape = new SweepHandShape();
                LineHandShape sweepHandShape = new LineHandShape();
                PinShape pinShape = new PinShape();

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        public static ShapeSet Blue
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DialShape(Color.LightBlue, Color.LightBlue, 1),
                    new TextShape()
                };

                TicksShape ticks1Shape = new TicksShape(Color.RoyalBlue, 7.5f, 0.75f, 5f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Navy, 5f, 15f, 5f);
                ticks5Shape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    new DustInTheWind.Clock.Shapes.Default.TextAngularShape(Color.Navy)
                };

                HourHandShape hourHandShape = new HourHandShape(Color.Empty, Color.Navy);
                MinuteHandShape minuteHandShape = new MinuteHandShape(Color.Empty, Color.RoyalBlue);
                //SweepHandShape sweepHandShape = new SweepHandShape(Color.DeepSkyBlue);
                LineHandShape sweepHandShape = new LineHandShape(Color.DeepSkyBlue);
                PinShape pinShape = new PinShape(Color.Empty, Color.Navy);

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        public static ShapeSet Black
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new FancyDialShape(Color.Black),
                    new TextShape("Black", Color.LightGray)
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 3f, 0.3f, 8f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.LightGray, 3f, 1f, 8f);
                ticks5Shape.Angle = 30f;

                TextAngularShape hourShapes = new TextAngularShape(Color.WhiteSmoke, new Font("Arial", 5f, FontStyle.Regular, GraphicsUnit.Point), 13f);

                TextAngularShape minuteShapes = new TextAngularShape(Color.WhiteSmoke, new Font("Arial", 2.2f, FontStyle.Regular, GraphicsUnit.Point), 0.7f);
                minuteShapes.Numbers = new string[] { "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" };

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    hourShapes,
                    minuteShapes
                };

                HourHandShape hourHandShape = new HourHandShape();
                MinuteHandShape minuteHandShape = new MinuteHandShape();
                LineHandShape sweepHandShape = new LineHandShape(Color.Red);
                PinShape pinShape = new PinShape();

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        public static ShapeSet Fancy
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    new DustInTheWind.Clock.Shapes.Default.TextShape()
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 3f, 0.3f, 0f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 3f, 1f, 0f);
                ticks5Shape.Angle = 30f;

                TextAngularShape numbersShape = new TextAngularShape();
                numbersShape.PositionOffset = 6f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    numbersShape
                };

                HourHandShape hourHandShape = new HourHandShape();
                BigNibHandShape minuteHandShape = new BigNibHandShape();
                FancySweepHandShape sweepHandShape = new FancySweepHandShape();
                PinShape pinShape = new PinShape();

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        public static ShapeSet BlackDot
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(Color.Black, Color.White, 2)
                };

                IAngularShape[] angulars = null;

                EllipseHandShape hourHandShape = new EllipseHandShape(Color.Black, 20, 4.5f);
                EllipseHandShape minuteHandShape = new EllipseHandShape(Color.Black, 40, 2.75f);
                //SweepHandShape sweepHandShape = null;
                LineHandShape sweepHandShape = null;
                PinShape pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Black, 8);

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        public static ShapeSet WhiteFancy
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DustInTheWind.Clock.Shapes.Default.DialShape(Color.Black)
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 5f, 0.3f, 7f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 5f, 1f, 7f);
                ticks5Shape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    new TextAngularShape(Color.White, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point), 13)
                };

                SlotHandShape hourHandShape = new SlotHandShape(Color.White, 49, 34, 6);
                LineHandShape minuteHandShape = new LineHandShape(Color.Black, 42, 3, 0);
                LineHandShape sweepHandShape = new LineHandShape(Color.Black, 45, 1, 15);
                PinShape pinShape = new PinShape(Color.Black, 9);

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        public static ShapeSet ImageShapes
        {
            get
            {
                IShape[] backgrounds = new IShape[]{
                    new DialShape(),
                    new TextShape("Image Hands", Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
                };

                TicksShape ticks1Shape = new TicksShape(Color.Black, 3.33f, 0.25f, 0f);
                ticks1Shape.Angle = 6f;
                ticks1Shape.ExceptionIndex = 5;

                TicksShape ticks5Shape = new TicksShape(Color.Black, 3.33f, 3f, 0f);
                ticks5Shape.Angle = 30f;

                TextAngularShape numbersShape = new TextAngularShape(Color.Black, new Font("Viner Hand ITC", 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), 5f);
                numbersShape.Angle = 30f;

                IAngularShape[] angulars = new IAngularShape[]{
                    ticks1Shape,
                    ticks5Shape,
                    numbersShape
                };

                ImageHandShape hourHandShape = new ImageHandShape(Resources.hour_hand, new PointF(32f, 155.5f), 25);
                ImageHandShape minuteHandShape = new ImageHandShape(Resources.minute_hand, new PointF(14.5f, 206f), 35);
                LineHandShape sweepHandShape = new LineHandShape(Color.Red);
                PinShape pinShape = new PinShape();

                return new ShapeSet()
                {
                    backgroundShapes = backgrounds,
                    angularShapes = angulars,
                    hourHandShape = hourHandShape,
                    minuteHandShape = minuteHandShape,
                    sweepHandShape = sweepHandShape,
                    pinShape = pinShape
                };
            }
        }

        private IShape[] backgroundShapes;

        public IShape[] BackgroundShapes
        {
            get { return backgroundShapes; }
            set { backgroundShapes = value; }
        }

        private IAngularShape[] angularShapes;

        public IAngularShape[] AngularShapes
        {
            get { return angularShapes; }
            set { angularShapes = value; }
        }

        /// <summary>
        /// An instance of <see cref="IHandShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        private IHandShape hourHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IHandShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        public IHandShape HourHandShape
        {
            get { return hourHandShape; }
            set { hourHandShape = value; }
        }

        /// <summary>
        /// An instance of <see cref="IHandShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        private IHandShape minuteHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IHandShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        public IHandShape MinuteHandShape
        {
            get { return minuteHandShape; }
            set { minuteHandShape = value; }
        }

        /// <summary>
        /// An instance of <see cref="IHandShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        private IHandShape sweepHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IHandShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        public IHandShape SweepHandShape
        {
            get { return sweepHandShape; }
            set { sweepHandShape = value; }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the pin from the center of the clock.
        /// </summary>
        private IShape pinShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the pin from the center of the clock.
        /// </summary>
        public IShape PinShape
        {
            get { return pinShape; }
            set { pinShape = value; }
        }
    }
}
