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

namespace DustInTheWind.Clock.Shapes
{
    public class ShapeSet
    {
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
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(Color.Black, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point)),
                    textShape = new DustInTheWind.Clock.Shapes.Default.TextShape(Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point), VectorialDrawMode.Fill)
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
                    hourHandShape = new DustInTheWind.Clock.Shapes.Default.HourHandShape(Color.Navy, Color.Navy, VectorialDrawMode.Fill),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Default.MinuteHandShape(Color.RoyalBlue, Color.RoyalBlue, VectorialDrawMode.Fill),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Default.SweepHandShape(Color.DeepSkyBlue, Color.DeepSkyBlue),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Navy, Color.Navy, VectorialDrawMode.Fill),
                    ticks1Shape = new DustInTheWind.Clock.Shapes.Default.Ticks1Shape(Color.RoyalBlue, Color.RoyalBlue, 7.5f, 0.75f, 5f),
                    ticks5Shape = new DustInTheWind.Clock.Shapes.Default.Ticks5Shape(Color.Navy, Color.Navy, 15f, 5f),
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(Color.Navy, Color.Navy, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point)),
                    textShape = new DustInTheWind.Clock.Shapes.Default.TextShape(Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point), VectorialDrawMode.Fill)
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
                    hourHandShape = new DustInTheWind.Clock.Shapes.Fancy.HourHandShape(),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Default.MinuteHandShape(),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.Fancy.SweepHandShape(),
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
                    hourHandShape = new DustInTheWind.Clock.Shapes.Fancy.DotHandShape(Color.Black, 15, 10),
                    minuteHandShape = new DustInTheWind.Clock.Shapes.Fancy.DotHandShape(Color.Black, 38, 5),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Black, 9),
                    textShape = new DustInTheWind.Clock.Shapes.Default.TextShape(Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point), VectorialDrawMode.Fill)
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
                    minuteHandShape = new DustInTheWind.Clock.Shapes.LineHandShape(Color.Black, 42, 3, 0),
                    sweepHandShape = new DustInTheWind.Clock.Shapes.LineHandShape(Color.Black, 45, 1, 15),
                    pinShape = new DustInTheWind.Clock.Shapes.Default.PinShape(Color.Black, 9),
                    numbersShape = new DustInTheWind.Clock.Shapes.Default.NumbersShape(Color.White, new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point)),
                    textShape = new DustInTheWind.Clock.Shapes.Default.TextShape(Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point), VectorialDrawMode.Fill)
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
        /// An instance of <see cref="IShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        private IShape hourHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the hour hand in the position specified by the clock.
        /// </summary>
        public IShape HourHandShape
        {
            get { return hourHandShape; }
            set { hourHandShape = value; }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        private IShape minuteHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the minute hand in the position specified by the clock.
        /// </summary>
        public IShape MinuteHandShape
        {
            get { return minuteHandShape; }
            set { minuteHandShape = value; }
        }

        /// <summary>
        /// An instance of <see cref="IShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        private IShape sweepHandShape;

        /// <summary>
        /// Gets or sets an instance of <see cref="IShape"/> responsable to paint the sweep hand in the position specified by the clock.
        /// </summary>
        public IShape SweepHandShape
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
