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
                return new ShapeSet()
                {
                    dialShape = new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    hourHandShape = new DustInTheWind.Clock.Shapes.Default.HourHandShape(),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Default.MinuteHandShape(),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Default.SweepHandShape(),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(),
                    ticks1Shape = new DustInTheWind.Clock.Shapes.Default.Ticks1Shape(),
                    ticks5Shape = new DustInTheWind.Clock.Shapes.Default.Ticks5Shape(),
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(),
                    textShape = new DustInTheWind.Clock.Shapes.Default.TextShape()
                };
            }
        }

        public static ShapeSet Blue
        {
            get
            {
                return new ShapeSet()
                {
                    dialShape = new DustInTheWind.Clock.Shapes.Default.DialShape(Color.LightBlue, Color.LightBlue, 1),
                    hourHandShape = new DustInTheWind.Clock.Shapes.Default.HourHandShape(Color.Empty, Color.Navy),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Default.MinuteHandShape(Color.Empty, Color.RoyalBlue),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Default.SweepHandShape(Color.DeepSkyBlue),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Empty, Color.Navy),
                    ticks1Shape = new DustInTheWind.Clock.Shapes.Default.Ticks1Shape(Color.RoyalBlue, 7.5f, 0.75f, 5f),
                    ticks5Shape = new DustInTheWind.Clock.Shapes.Default.Ticks5Shape(Color.Navy, Color.Navy, 15f, 5f),
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(Color.Navy)
                };
            }
        }

        public static ShapeSet Fancy
        {
            get
            {
                return new ShapeSet()
                {
                    dialShape = new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    hourHandShape = new DustInTheWind.Clock.Shapes.Default.HourHandShape(),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Fancy.BigRainDropHandShape(),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Fancy.FancySweepHandShape(),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(),
                    ticks1Shape = new DustInTheWind.Clock.Shapes.Default.Ticks1Shape(),
                    ticks5Shape = new DustInTheWind.Clock.Shapes.Default.Ticks5Shape(),
                    numbersShape = new DustInTheWind.Clock.Shapes.Fancy.NumbersShape()
                };
            }
        }

        public static ShapeSet BlackDot
        {
            get
            {
                return new ShapeSet()
                {
                    dialShape = new DustInTheWind.Clock.Shapes.Default.DialShape(Color.Black, Color.White, 2),
                    hourHandShape = new DustInTheWind.Clock.Shapes.Fancy.DotHandShape(Color.Black, 15, 9),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Fancy.DotHandShape(Color.Black, 36, 5.5f),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Black, 8),
                };
            }
        }

        public static ShapeSet WhiteFancy
        {
            get
            {
                ShapeSet set = new ShapeSet()
                {
                    dialShape = new DustInTheWind.Clock.Shapes.Default.DialShape(Color.Black),
                    hourHandShape = new DustInTheWind.Clock.Shapes.Fancy.SlotHandShape(Color.White, 49, 34, 6),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Basic.LineHandShape(Color.Black, 42, 3, 0),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Basic.LineHandShape(Color.Black, 45, 1, 15),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Black, 9),
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(Color.White, new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point), 13)
                };

                return set;
            }
        }

        public static ShapeSet ImageShapes
        {
            get
            {
                ShapeSet set = new ShapeSet()
                {
                    dialShape = new DustInTheWind.Clock.Shapes.Default.DialShape(),
                    hourHandShape = new DustInTheWind.Clock.Shapes.Basic.ImageHandShape(Resources.hour_hand, new PointF(32f, 155.5f), 25),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Basic.ImageHandShape(Resources.minute_hand, new PointF(14.5f, 206f), 35),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Default.SweepHandShape(),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(),
                    ticks1Shape = new DustInTheWind.Clock.Shapes.Default.Ticks1Shape(Color.Black, 3.33f, 0.25f, 0f),
                    ticks5Shape = new DustInTheWind.Clock.Shapes.Default.Ticks5Shape(Color.Black, Color.Empty, 5, 3.33f),
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(Color.Black, new Font("Viner Hand ITC", 7.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))),
                    textShape = new DustInTheWind.Clock.Shapes.Default.TextShape("Image Hands", Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
                };

                return set;
            }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the dial's background.
        /// </summary>
        private IShape dialShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the dial's background.
        /// </summary>
        public IShape DialShape
        {
            get { return dialShape; }
            set { dialShape = value; }
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

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the tick lines that marks the seconds.
        /// </summary>
        private IShape ticks1Shape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the tick lines that marks the seconds.
        /// </summary>
        public IShape Ticks1Shape
        {
            get { return ticks1Shape; }
            set { ticks1Shape = value; }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the tick lines that marks every 5 seconds.
        /// </summary>
        private IShape ticks5Shape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the tick lines that marks every 5 seconds.
        /// </summary>
        public IShape Ticks5Shape
        {
            get { return ticks5Shape; }
            set { ticks5Shape = value; }
        }

        /// <summary>
        /// An instance of <see cref="INumbersShape"/> responsable to paint the numbers that marks the hours.
        /// </summary>
        private IArrayShape numbersShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the numbers that marks the hours.
        /// </summary>
        public IArrayShape NumbersShape
        {
            get { return numbersShape; }
            set { numbersShape = value; }
        }

        /// <summary>
        /// An instance of <see cref="INumbersShape"/> responsable to paint the text displayed on the background of the clock.
        /// </summary>
        private IShape textShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the text displayed on the background of the clock.
        /// </summary>
        public IShape TextShape
        {
            get { return textShape; }
            set { textShape = value; }
        }
    }
}
